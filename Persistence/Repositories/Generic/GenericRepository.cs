// ©2023 https://www.linkedin.com/in/faysal-belkhadir | Product: Faysal Belkhadir

namespace MicroserviceWithCleanArchitecture.Persistence.Repositories.Generic;

public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : BaseEntity
{
    protected DatabaseContext DbContext;

    public GenericRepository(DatabaseContext dbContext)
    {
        DbContext = dbContext;
    }

    #region Queries

    public async Task<TEntity?> FirstOrDefaultAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null
    )
    {
        var query = DbContext.Set<TEntity>().AsQueryable();

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        if (include != null)
        {
            query = include(query);
        }

        return await query.FirstOrDefaultAsync();
    }

    public async Task<TEntity?> SingleOrDefaultAsync(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null
    )
    {
        var query = DbContext.Set<TEntity>().AsQueryable();

        if (include != null)
        {
            query = include(query);
        }

        return await query.SingleOrDefaultAsync(predicate);
    }

    public async Task<bool> AnyAsync(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null
    )
    {
        var query = DbContext.Set<TEntity>().AsQueryable();

        if (include != null)
        {
            query = include(query);
        }

        return await query.AnyAsync(predicate);
    }

    public async Task<List<TEntity>> ListAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null
    )
    {
        var query = DbContext.Set<TEntity>().AsQueryable();

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        if (include != null)
        {
            query = include(query);
        }

        return await query.ToListAsync();
    }

    #endregion

    #region Commands

    public async Task AddAsync(TEntity entity)
    {
        await DbContext.AddAsync(entity);
    }

    public TEntity Delete(TEntity entity)
    {
        return DbContext.Remove(entity).Entity;
    }

    public TEntity Update(TEntity entity)
    {
        return DbContext.Update(entity).Entity;
    }

    public int SaveChanges()
    {
        return DbContext.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await DbContext.SaveChangesAsync();
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await DbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        await DbContext.Database.CommitTransactionAsync();
    }

    public async Task RollbackTransactionAsync()
    {
        await DbContext.Database.RollbackTransactionAsync();
    }

    #endregion

    #region Dispose Synch

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposing)
        {
            return;
        }

        DbContext.Dispose();
    }

    #endregion

    #region Dispose Async

    public async ValueTask DisposeAsync()
    {
        await DisposeAsync(true);
        GC.SuppressFinalize(this);
    }

    protected virtual async Task DisposeAsync(bool disposing)
    {
        if (!disposing)
        {
            return;
        }

        await DbContext.DisposeAsync();
    }

    #endregion
}
