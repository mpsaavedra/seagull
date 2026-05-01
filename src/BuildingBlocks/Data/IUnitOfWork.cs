using System;

namespace Seagull.Data;

/// <summary>
/// Unit of work to centralize database operations
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="operation"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    Task<Maybe<TResult>> ExecuteAsync<TResult>(Func<Task<TResult>> operation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Save changes to the database
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// commit current transaction if any
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Result> CommitAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Roll back the current transaction if any
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Result> RollbackAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a repository for  TEntity
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <returns></returns>
    IRepository<TEntity> Repository<TEntity>()
        where TEntity : class, IEntity;
}

