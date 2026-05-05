using System;
using System.Linq.Expressions;
using JasperFx.Core.IoC;
using Microsoft.EntityFrameworkCore;

namespace Seagull.Data.EntityFrameworkCore;

public class Service<TEntity, TDbContext> : IService<TEntity>
    where TEntity : class, IEntity
    where TDbContext : DbContext
{
    protected readonly TDbContext DbContext;
    protected readonly DbSet<TEntity> DbSet;
    protected readonly IRepository<TEntity> Repository;

    public Service(TDbContext dbContext)
    {
        DbContext = dbContext;
        DbSet = dbContext.Set<TEntity>();
        Repository = new Repository<TEntity, TDbContext>(dbContext);
    }


    public virtual Task<Maybe<string>> AddAsync(TEntity entity, CancellationToken cancellationToken = default) =>
        Repository.AddAsync(entity, cancellationToken);

    public virtual Task<Maybe<bool>> AnyAsync(Expression<Func<TEntity, bool>>? expression = null, bool softdelete = true, 
        CancellationToken cancellationToken = default) =>
        Repository.AnyAsync(expression, softdelete, cancellationToken);

    public virtual Task<Maybe<bool>> DeleteAsync(TEntity entity, bool softdelete = true, 
        CancellationToken cancellationToken = default) =>
        DeleteAsync(entity, softdelete, cancellationToken);

    public virtual Task<Maybe<TEntity>> FindByIdAsync(string id, CancellationToken cancellationToken = default) =>
        FindByIdAsync(id, cancellationToken);

    public virtual Task<Maybe<TEntity>> FirstOrDefaultAsync(Expression<Func<TEntity, bool>>? expression = null, 
        CancellationToken cancellationToken = default) =>
        FirstOrDefaultAsync(expression, cancellationToken);

    public virtual Task<Maybe<IQueryable<TEntity>>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, 
        int pageIndex = 1, int pageSize = 50, bool includeSoftDeleted = false, 
        CancellationToken cancellationToken = default) =>
        Repository.GetAllAsync(predicate, pageIndex, pageSize, includeSoftDeleted, cancellationToken);

    public virtual Task<Maybe<long>> LongCountAsync(Expression<Func<TEntity, bool>>? expression = null, bool softdelete = true, 
        CancellationToken cancellationToken = default) =>
        LongCountAsync(expression, softdelete, cancellationToken);

    public virtual Task<Maybe<bool>> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default) =>
        UpdateAsync(entity, cancellationToken);
}
