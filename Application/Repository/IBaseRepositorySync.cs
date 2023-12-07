using System.Linq.Expressions;

namespace Application.Repository; 

public interface IBaseRepositorySync <TEntity, in TKey> 
    where TEntity : class {
    IEnumerable<TEntity> ToList();
    TEntity? GetById(TKey key);

    TEntity? Find(Expression<Func<TEntity, bool>> predicate,
        params Expression<Func<TEntity, object>>[]? includeProperties);


    bool Any(Expression<Func<TEntity, bool>> predicate);
    
    IEnumerable<TEntity> FindAll(
        Expression<Func<TEntity, bool>>? predicate,
        int? skip,
        int? take,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy,
        params Expression<Func<TEntity, object>>[]? includeProperties);

    TEntity Add(TEntity entity);
    TEntity Update(TEntity entity);
    void Remove(TEntity entity);
    void Attach(TEntity entity);
    int Count(Expression<Func<TEntity, bool>>? predicate);
    long CountLong(Expression<Func<TEntity, bool>>? predicate);
}