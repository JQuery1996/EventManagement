using System.Linq.Expressions;

namespace Application.Repository; 

public interface IBaseRepositoryAsync <TEntity, in TKey> 
    where TEntity : class {

    Task<IEnumerable<TEntity>> ToListAsync();
    Task<TEntity?> GetByIdAsync(TKey key);

    Task<TEntity?> FindAsync(
        Expression<Func<TEntity, bool>> predicate,
        params Expression<Func<TEntity, object>>[]? includeProperties
    );

    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
    Task<IEnumerable<TEntity>> FindAllAsync(
        Expression<Func<TEntity, bool>> predicate,
        int? skip = null ,
        int? take = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        params Expression<Func<TEntity, object>>[]? includeProperties);


    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task RemoveAsync(TEntity entity);
    Task AttachAsync(TEntity entity);
    Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate);
    Task<long> LongCountAsync(Expression<Func<TEntity, bool>>? predicate);
}