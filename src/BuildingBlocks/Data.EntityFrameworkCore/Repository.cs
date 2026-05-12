using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Seagull.Data;
using System.Linq.Expressions;

namespace Seagull.Data.EntityFrameworkCore;


public class Repository<TEntity, TDbContext>(TDbContext dbContext) : IRepository<TEntity>
    where TEntity : class, IEntity
    where TDbContext : DbContext
{
    protected readonly TDbContext DbContext = dbContext;
    protected readonly DbSet<TEntity> DbSet = dbContext.Set<TEntity>();

    public virtual async Task<Maybe<TEntity>> FindByIdAsync(string id,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool includeSoftDeleted = false, CancellationToken cancellationToken = default)
    {

        var query = DbContext.Set<TEntity>().AsNoTracking();

        if (!includeSoftDeleted)
        {
            query = query.Where(x => !x.IsDeleted);
        }
        if (include is not null)
        {
            query = include(query);
        }

        var entity = await query.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        return entity != null ? Maybe<TEntity>.From(entity) : Maybe<TEntity>.None!;
    }

    public virtual async Task<Maybe<TEntity>> FirstOrDefaultAsync(Expression<Func<TEntity, bool>>? expression = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool includeSoftDeleted = false, CancellationToken cancellationToken = default)
    {
        var query = DbContext.Set<TEntity>().AsNoTracking();

        if (!includeSoftDeleted)
        {
            query = query.Where(x => !x.IsDeleted);
        }

        if (expression != null)
        {
            query = query.Where(expression);
        }
        if (include is not null)
        {
            query = include(query);
        }

        var entity = await query.FirstOrDefaultAsync(cancellationToken);
        return entity != null ? Maybe<TEntity>.From(entity) : Maybe<TEntity>.None!;
    }

    public virtual async Task<Maybe<(List<TEntity> data, bool hasPreviousPage, bool hasNextPage)>> GetAllAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int pageIndex = 1, int pageSize = 50,
        bool includeSoftDeleted = false,
        CancellationToken cancellationToken = default)
    {
        bool hasPreviousPage = false;
        bool hasNextPage = false;
        var query = DbContext.Set<TEntity>().AsNoTracking();

        if (!includeSoftDeleted)
        {
            query = query.Where(x => !x.IsDeleted);
        }

        if (include is not null)
        {
            query = include(query);
        }

        if (predicate is not null)
        {
            query = query.Where(predicate);
        }

        // if (ignoreQueryFilters)
        // {
        //     query = query.IgnoreQueryFilters();
        // }

        if (orderBy is not null)
        {
            query = orderBy(query);
        }

        var count = query.Count();

        if (pageIndex > 0)
        {
            pageIndex = pageIndex > 0 ? pageIndex : 1;
            pageSize = pageSize > 0 ? pageSize : 50;
            pageIndex = (pageIndex - 1) * pageSize;
            query = query.Skip(pageIndex).Take(pageSize);
        }
        hasPreviousPage = pageIndex > pageSize;
        hasNextPage = pageIndex + pageSize < count;

        var list = query.ToList();

        return await Task.FromResult(
            Maybe<(List<TEntity> Data, bool HasPreviousPage, bool HasNextPage)>
                .From((list, hasPreviousPage, hasNextPage)));
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
        if (softdelete)
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

    public async Task<Maybe<long>> LongCountAsync(Expression<Func<TEntity, bool>>? expression = null, bool includeSoftDeleted = false,
        CancellationToken cancellationToken = default)
    {
        var query = DbSet.AsQueryable();
        if (expression != null)
            query = query.Where(expression);

        if (!includeSoftDeleted)
            query = query.Where(x => !x.IsDeleted);

        var count = await query.LongCountAsync(cancellationToken);

        return await Task.FromResult(Maybe<long>.From(count));
    }

    public async Task<Maybe<bool>> AnyAsync(Expression<Func<TEntity, bool>>? expression = null, bool includeSoftDeleted = false,
        CancellationToken cancellationToken = default)
    {
        var query = DbSet.AsQueryable();
        if (expression != null)
            query = query.Where(expression);

        if (!includeSoftDeleted)
            query = query.Where(x => !x.IsDeleted);

        var count = await query.AnyAsync(cancellationToken);

        return await Task.FromResult(Maybe<bool>.From(count));
    }
}
