using System;
using System.Linq.Expressions;
using AutoMapper;
using ImTools;
using JasperFx.Core.IoC;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Seagull.Data.EntityFrameworkCore;

public class Service<TEntity, TDbContext>
    (TDbContext dbContext, IMapper mapper, ILogger logger) :
    IService<TEntity>
    where TEntity : class, IEntity
    where TDbContext : DbContext
{
    protected readonly TDbContext DbContext = dbContext;
    protected readonly IMapper Mapper = mapper;
    protected readonly ILogger Logger = logger;

    public async Task<Maybe<TEntity>> FindByIdAsync(string id, bool softDeleted = false,
        CancellationToken cancellationToken = default)
    {
        Logger.LogInformation($"Searching for '{nameof(TEntity)}' with Id: {id}");

        var query = DbContext.Set<TEntity>().AsNoTracking();

        if (!softDeleted)
        {
            query = query.Where(x => !x.IsDeleted);
        }

        var entity = await query.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        Logger.LogDebug(entity is null ? $"No entitites hs been found" : "The entity was found");
        return entity != null ? Maybe<TEntity>.From(entity) : Maybe<TEntity>.None!;
    }
    public async Task<Maybe<TEntity>> FirstOrDefaultAsync(Expression<Func<TEntity, bool>>? expression = null,
        bool softDeleted = false, CancellationToken cancellationToken = default)

    {
        var query = DbContext.Set<TEntity>().AsNoTracking();

        if (!softDeleted)
        {
            query = query.Where(x => !x.IsDeleted);
        }

        if (expression != null)
        {
            query = query.Where(expression);
        }

        var entity = await query.FirstOrDefaultAsync(cancellationToken);
        return entity != null ? Maybe<TEntity>.From(entity) : Maybe<TEntity>.None!;
    }

    public async Task<Maybe<(List<TEntity> Data, bool HasPreviousPage, bool HasNextPage)>> GetAllAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        int pageIndex = 1, int pageSize = 50,
        bool includeSoftDeleted = false, CancellationToken cancellationToken = default)

    {
        bool hasPreviousPage = false;
        bool hasNextPage = false;
        var query = DbContext.Set<TEntity>().AsNoTracking();

        if (!includeSoftDeleted)
        {
            query = query.Where(x => !x.IsDeleted);
        }

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        if (pageIndex > 0)
        {
            pageSize = pageSize > 0 ? pageSize : 50;
            pageIndex = (pageIndex - 1) * pageSize;
            query = query.Skip(pageIndex).Take(pageSize);
        }
        var list = query.ToList();

        return await Task.FromResult(
            Maybe<(List<TEntity> Data, bool HasPreviousPage, bool HasNextPage)>
                .From((list, hasPreviousPage, hasNextPage)));
    }

    public async Task<Maybe<string>> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        try
        {

            var entityEntry = await DbContext.Set<TEntity>().AddAsync(entity, cancellationToken);

            await DbContext.SaveChangesAsync(cancellationToken);

            return Maybe<string>.From(entityEntry.Entity.Id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Maybe<bool>> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Maybe<bool>> DeleteAsync(TEntity entity, bool softDelete = true, CancellationToken cancellationToken = default)

    {
        throw new NotImplementedException();
    }

    public async Task<Maybe<long>> LongCountAsync(Expression<Func<TEntity, bool>>? expression = null, bool softDeleted = false,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Maybe<bool>> AnyAsync(Expression<Func<TEntity, bool>>? expression = null, bool softDeleted = false,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    #region old implementation with repositories


    // protected readonly IUnitOfWork UoW;

    // public Service(IUnitOfWork uow)
    // {
    //     UoW = uow;
    // }


    // public virtual Task<Maybe<string>> AddAsync(TEntity entity, CancellationToken cancellationToken = default) =>
    //     UoW.Repository<TEntity>().AddAsync(entity, cancellationToken);

    // public virtual Task<Maybe<bool>> AnyAsync(Expression<Func<TEntity, bool>>? expression = null, bool softdelete = true, 
    //     CancellationToken cancellationToken = default) =>
    //     UoW.Repository<TEntity>().AnyAsync(expression, softdelete, cancellationToken);

    // public virtual Task<Maybe<bool>> DeleteAsync(TEntity entity, bool softdelete = true, 
    //     CancellationToken cancellationToken = default) =>
    //     UoW.Repository<TEntity>().DeleteAsync(entity, softdelete, cancellationToken);

    // public virtual Task<Maybe<TEntity>> FindByIdAsync(string id, CancellationToken cancellationToken = default) =>
    //     FindByIdAsync(id, cancellationToken);

    // public virtual Task<Maybe<TEntity>> FirstOrDefaultAsync(Expression<Func<TEntity, bool>>? expression = null, 
    //     CancellationToken cancellationToken = default) =>
    //     UoW.Repository<TEntity>().FirstOrDefaultAsync(expression, cancellationToken);

    // public virtual Task<Maybe<(IQueryable<TEntity> data, bool hasPreviousPage, bool hasNextPage)>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, 
    //     int pageIndex = 1, int pageSize = 50, bool includeSoftDeleted = false, 
    //     CancellationToken cancellationToken = default) =>
    //     UoW.Repository<TEntity>().GetAllAsync(predicate, pageIndex, pageSize, includeSoftDeleted, cancellationToken);

    // public virtual Task<Maybe<long>> LongCountAsync(Expression<Func<TEntity, bool>>? expression = null, bool softdelete = true, 
    //     CancellationToken cancellationToken = default) =>
    //     UoW.Repository<TEntity>().LongCountAsync(expression, softdelete, cancellationToken);

    // public virtual Task<Maybe<bool>> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default) =>
    //     UoW.Repository<TEntity>().UpdateAsync(entity, cancellationToken);


    #endregion
}
