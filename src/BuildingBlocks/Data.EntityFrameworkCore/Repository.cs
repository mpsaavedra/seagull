using Microsoft.EntityFrameworkCore;
using Seagull.Data;
using System.Linq.Expressions;

namespace Seagull.Data.EntityFrameworkCore;


public class Repository<TEntity, TDbContext>(TDbContext dbContext) : IRepository<TEntity>
    where TEntity : class, IEntity
    where TDbContext : DbContext
{
    protected readonly TDbContext DbContext = dbContext;
    protected readonly DbSet<TEntity> DbSet = dbContext.Set<TEntity>();

    public virtual async Task<Maybe<TEntity>> FindByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var entity = await DbSet.FindAsync(new object[] { id! }, cancellationToken);
        return entity != null ? Maybe<TEntity>.From(entity) : Maybe<TEntity>.None!;
    }

    public virtual async Task<Maybe<TEntity>> FirstOrDefaultAsync(Expression<Func<TEntity, bool>>? expression = null,
        CancellationToken cancellationToken = default)
    {
        var query = DbSet.AsQueryable();
        if (expression != null)
        {
            query = query.Where(expression);
        }

        var entity = await query.FirstOrDefaultAsync(cancellationToken);
        return entity != null ? Maybe<TEntity>.From(entity) : Maybe<TEntity>.None!;
    }

    public virtual async Task<Maybe<IQueryable<TEntity>>> GetAllAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        bool includeSoftDeleted = false,
        CancellationToken cancellationToken = default)
    {
        var query = DbSet.AsQueryable();
        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        return await Task.FromResult(Maybe<IQueryable<TEntity>>.From(query));
    }

    public virtual async Task<Maybe<string>> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await DbSet.AddAsync(entity, cancellationToken);

        // This is a bit tricky since we don't know the Id property name for sure, 
        // but by convention in this project it seems to be 'Id'.
        var idProperty = entity.GetType().GetProperty("Id");
        if (idProperty != null)
        {
            return (string)idProperty.GetValue(entity)!;
        }

        return Maybe<string>.None!;
    }

    public virtual async Task<Maybe<bool>> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        DbSet.Update(entity);
        return await Task.FromResult(true);
    }

    public virtual async Task<Maybe<bool>> DeleteAsync(TEntity entity, bool softdelete = true, 
        CancellationToken cancellationToken = default)
    {
        if(softdelete)
        {
            entity.MarkAsDeleted();
            DbSet.Update(entity);
        }
        else
        {
            DbSet.Remove(entity);    
        }
        
        return await Task.FromResult(true);
    }

    public async Task<Maybe<long>> LongCountAsync(Expression<Func<TEntity, bool>>? expression = null,  bool includeSoftDeleted = false, 
        CancellationToken cancellationToken = default)
    {
        var query = DbSet.AsQueryable();
        if(expression != null)
            query = query.Where(expression);
        
        if(!includeSoftDeleted) 
            query = query.Where(x => !x.IsDeleted);

        var count = await query.LongCountAsync(cancellationToken);
        
        return await Task.FromResult(Maybe<long>.From(count));
    }

    public async Task<Maybe<bool>> AnyAsync(Expression<Func<TEntity, bool>>? expression = null,  bool includeSoftDeleted = false, 
        CancellationToken cancellationToken = default)
    {
        var query = DbSet.AsQueryable();
        if(expression != null)
            query = query.Where(expression);
        
        if(!includeSoftDeleted) 
            query = query.Where(x => !x.IsDeleted);

        var count = await query.AnyAsync(cancellationToken);
        
        return await Task.FromResult(Maybe<bool>.From(count));
    }
}
