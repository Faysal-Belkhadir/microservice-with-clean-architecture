// ©2023 https://www.linkedin.com/in/faysal-belkhadir | Product: Faysal Belkhadir

namespace MicroserviceWithCleanArchitecture.Persistence.Repositories.Generic;

public interface IGenericRepository<TEntity> : IDisposable, IAsyncDisposable
    where TEntity : BaseEntity
{
    #region Queries

    Task<TEntity?> FirstOrDefaultAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null
    );

    Task<List<TEntity>> ListAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null
    );

    Task<bool> AnyAsync(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null
    );

    Task<TEntity?> SingleOrDefaultAsync(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null
    );

    #endregion

    #region Commands

    Task AddAsync(TEntity entity);

    TEntity Update(TEntity entity);

    TEntity Delete(TEntity entity);

    int SaveChanges();

    Task<int> SaveChangesAsync();

    public Task<IDbContextTransaction> BeginTransactionAsync();

    public Task CommitTransactionAsync();

    public Task RollbackTransactionAsync();

    #endregion
}
