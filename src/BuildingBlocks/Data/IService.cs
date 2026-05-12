using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace Seagull.Data;

public interface IService<TEntity> where TEntity : class, IEntity
{
    Task<Maybe<TEntity>> FindByIdAsync(string id, bool softDeleted = false, CancellationToken cancellationToken = default);
    Task<Maybe<TEntity>> FirstOrDefaultAsync(Expression<Func<TEntity, bool>>? expression = null,
        bool softDeleted = false, CancellationToken cancellationToken = default);
    Task<Maybe<(List<TEntity> Data, bool HasPreviousPage, bool HasNextPage)>> GetAllAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int pageIndex = 1, int pageSize = 50,
        bool includeSoftDeleted = false, CancellationToken cancellationToken = default);
    Task<Maybe<string>> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<Maybe<bool>> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<Maybe<bool>> DeleteAsync(TEntity entity, bool softDelete = true, CancellationToken cancellationToken = default);
    Task<Maybe<long>> LongCountAsync(Expression<Func<TEntity, bool>>? expression = null, bool softDeleted = false,
        CancellationToken cancellationToken = default);
    Task<Maybe<bool>> AnyAsync(Expression<Func<TEntity, bool>>? expression = null, bool softDeleted = false,
        CancellationToken cancellationToken = default);
}