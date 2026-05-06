using System;
using System.Linq.Expressions;
using JasperFx.Core.IoC;
using Microsoft.EntityFrameworkCore;

namespace Seagull.Data.EntityFrameworkCore;

public class Service<TEntity, TDbContext> : IService<TEntity>
    where TEntity : class, IEntity
    where TDbContext : DbContext
{
    protected readonly IUnitOfWork UoW;

    public Service(IUnitOfWork uow)
    {
        UoW = uow;
    }


    public virtual Task<Maybe<string>> AddAsync(TEntity entity, CancellationToken cancellationToken = default) =>
        UoW.Repository<TEntity>().AddAsync(entity, cancellationToken);

    public virtual Task<Maybe<bool>> AnyAsync(Expression<Func<TEntity, bool>>? expression = null, bool softdelete = true, 
        CancellationToken cancellationToken = default) =>
        UoW.Repository<TEntity>().AnyAsync(expression, softdelete, cancellationToken);

    public virtual Task<Maybe<bool>> DeleteAsync(TEntity entity, bool softdelete = true, 
        CancellationToken cancellationToken = default) =>
        UoW.Repository<TEntity>().DeleteAsync(entity, softdelete, cancellationToken);

    public virtual Task<Maybe<TEntity>> FindByIdAsync(string id, CancellationToken cancellationToken = default) =>
        FindByIdAsync(id, cancellationToken);

    public virtual Task<Maybe<TEntity>> FirstOrDefaultAsync(Expression<Func<TEntity, bool>>? expression = null, 
        CancellationToken cancellationToken = default) =>
        UoW.Repository<TEntity>().FirstOrDefaultAsync(expression, cancellationToken);

    public virtual Task<Maybe<(IQueryable<TEntity> data, bool hasPreviousPage, bool hasNextPage)>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, 
        int pageIndex = 1, int pageSize = 50, bool includeSoftDeleted = false, 
        CancellationToken cancellationToken = default) =>
        UoW.Repository<TEntity>().GetAllAsync(predicate, pageIndex, pageSize, includeSoftDeleted, cancellationToken);

    public virtual Task<Maybe<long>> LongCountAsync(Expression<Func<TEntity, bool>>? expression = null, bool softdelete = true, 
        CancellationToken cancellationToken = default) =>
        UoW.Repository<TEntity>().LongCountAsync(expression, softdelete, cancellationToken);

    public virtual Task<Maybe<bool>> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default) =>
        UoW.Repository<TEntity>().UpdateAsync(entity, cancellationToken);
}
