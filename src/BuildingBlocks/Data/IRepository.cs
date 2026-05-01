using System.Linq.Expressions;

namespace Seagull.Data;

public interface IRepository<TEntity> where TEntity : IEntity
{
    Task<Maybe<TEntity>> FindByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<Maybe<TEntity>> FirstOrDefaultAsync(Expression<Func<TEntity, bool>>? expression = null,
        CancellationToken cancellationToken = default);
    Task<Maybe<IQueryable<TEntity>>> GetAllAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        bool includeSoftDeleted = false,
        CancellationToken cancellationToken = default);
    Task<Maybe<string>> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<Maybe<bool>> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<Maybe<bool>> DeleteAsync(TEntity entity, bool softdelete = true, CancellationToken cancellationToken = default);
    Task<Maybe<long>> LongCountAsync(Expression<Func<TEntity, bool>>? expression = null,  bool softdelete = true, 
        CancellationToken cancellationToken = default);
    Task<Maybe<bool>> AnyAsync(Expression<Func<TEntity, bool>>? expression = null,  bool softdelete = true, 
        CancellationToken cancellationToken = default);
}
