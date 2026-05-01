using Microsoft.EntityFrameworkCore;
using Seagull.Data;
using Seagull.Messaging;
using Seagull.Data.EntityFrameworkCore;

namespace Seagull.Data;

// <summary>
/// Unit of Work implementation that uses IMessageBus to ensure
/// domain events are published as part of the transaction.
/// </summary>
public class UnitOfWork<TDbContext>(TDbContext dbContext, IMessageBus messageBus) : IUnitOfWork
    where TDbContext : DbContext
{
    private readonly TDbContext _dbContext = dbContext;
    private readonly IMessageBus _messageBus = messageBus;
    private readonly Dictionary<Type, object> _repositories = new();

    public async Task<Maybe<TResult>> ExecuteAsync<TResult>(Func<Task<TResult>> operation, 
        CancellationToken cancellationToken = default)
    {
        var strategy = _dbContext.Database.CreateExecutionStrategy();
        return await strategy.ExecuteAsync(async () =>
        {
            await using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var result = await operation();
                await transaction.CommitAsync(cancellationToken);
                return Maybe<TResult>.From(result);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        });
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // If the DbContext is a BaseDbContext, it will handle domain event publishing
        // via IMessageBus internally in its SaveChangesAsync override.
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Result> CommitAsync(CancellationToken cancellationToken = default)
    {
        if (_dbContext.Database.CurrentTransaction is null)
        {
            return Result.Success();
        }

        try
        {
            await _dbContext.Database.CurrentTransaction.CommitAsync(cancellationToken);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(new Error("UnitOfWork.CommitError", ex.Message));
        }
    }

    public async Task<Result> RollbackAsync(CancellationToken cancellationToken = default)
    {
        if (_dbContext.Database.CurrentTransaction is null)
        {
            return Result.Success();
        }

        try
        {
            await _dbContext.Database.CurrentTransaction.RollbackAsync(cancellationToken);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(new Error("UnitOfWork.RollbackError", ex.Message));
        }
    }

    public IRepository<TEntity> Repository<TEntity>()
        where TEntity : class, IEntity
    {
        var type = typeof(TEntity);

        if (_repositories.TryGetValue(type, out var repository))
        {
            return (IRepository<TEntity>)repository;
        }

        var repositoryInstance = new Repository<TEntity, TDbContext>(_dbContext);
        _repositories.Add(type, repositoryInstance);

        return repositoryInstance;
    }

    public void Dispose()
    {
        _dbContext.Dispose();
        GC.SuppressFinalize(this);
    }
}

