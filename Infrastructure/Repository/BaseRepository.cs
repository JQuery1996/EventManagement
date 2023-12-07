using System.Linq.Expressions;
using Application.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository; 

public class BaseRepository<TEntity, TKey >(ApplicationDbContext context)
    : IBaseRepository<TEntity, TKey> 
    where TEntity : class {
    private readonly DbSet<TEntity> _dbSet  = context.Set<TEntity>();
    public IEnumerable<TEntity> ToList() {
        return _dbSet.ToList();
    }

    public TEntity? GetById(TKey key) {
        return _dbSet.Find(key);
    }

    public TEntity? Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[]? includeProperties) {
        var query = _dbSet.AsQueryable();
        if (includeProperties is not null)
            query = includeProperties.Aggregate(
                query,
                (current, includeProperty) => current.Include(includeProperty));
        return query.FirstOrDefault(predicate);
    }

    public bool Any(Expression<Func<TEntity, bool>> predicate) {
        return _dbSet.Any(predicate);
    }
    public IEnumerable<TEntity> FindAll(
        Expression<Func<TEntity, bool>>? predicate, 
        int? skip, 
        int? take, 
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy, 
        params Expression<Func<TEntity, object>>[]? includeProperties) {
        var query = _dbSet.AsQueryable();
        if(predicate is not null)
            query = query.Where(predicate);
        if (includeProperties is not null)
            query = includeProperties.Aggregate(
                query,
                (current, includeProperty) => current.Include(includeProperty));

        if (skip.HasValue)
            query = query.Skip(skip.Value);
        
        if (take.HasValue)
            query = query.Take(take.Value);

        return orderBy is not null 
            ? orderBy(query).ToList() 
            : query.ToList();

    }

    public TEntity Add(TEntity entity) {
        _dbSet.Add(entity);
        return entity;
    }

    public TEntity Update(TEntity entity) {
        _dbSet.Update(entity);
        return entity;
    }

    public void Remove(TEntity entity) {
        _dbSet.Remove(entity);
    }

    public void Attach(TEntity entity) {
        _dbSet.Attach(entity);
    }

    public int Count(Expression<Func<TEntity, bool>>? predicate) {
        return predicate is null
            ? _dbSet.Count()
            : _dbSet.Count(predicate);
    }

    public long CountLong(Expression<Func<TEntity, bool>>? predicate) {
        return predicate is null
            ? _dbSet.LongCount()
            : _dbSet.LongCount(predicate);
    }

    public async Task<IEnumerable<TEntity>> ToListAsync() {
        return await _dbSet.ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(TKey key) {
        return await _dbSet.FindAsync(key);
    }

    public async Task<TEntity?> FindAsync(
        Expression<Func<TEntity, bool>> predicate, 
        params Expression<Func<TEntity, object>>[]? includeProperties) {
        var query =  _dbSet.AsQueryable();
        if (includeProperties is not null && includeProperties.Length > 0 )
            query = includeProperties.Aggregate(
                query, (current, includeProperty) => current.Include(includeProperty));

        return await query.FirstOrDefaultAsync(predicate);
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate) {
        return await _dbSet.AnyAsync(predicate);
    }
    public async Task<IEnumerable<TEntity>> FindAllAsync(
        Expression<Func<TEntity, bool>> predicate, 
        int? skip = null, 
        int? take = null , 
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, 
        params Expression<Func<TEntity, object>>[]? includeProperties) {
        var query = _dbSet.AsQueryable();
        query = query.Where(predicate);
        
        if (includeProperties is not null)
            query = includeProperties.Aggregate(
                query,
                (current, includeProperty) => current.Include(includeProperty));

        if (skip.HasValue)
            query = query.Skip(skip.Value);

        if (take.HasValue)
            query = query.Take(take.Value);

        return orderBy is not null
            ? await orderBy(query).ToListAsync()
            : await query.ToListAsync();
    }

    public async Task<TEntity> AddAsync(TEntity entity) {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity) {
        await Task.CompletedTask;
        _dbSet.Update(entity);
        return entity;
    }

    public async Task RemoveAsync(TEntity entity) {
        await Task.CompletedTask;
        _dbSet.Remove(entity);
    }

    public async Task AttachAsync(TEntity entity) {
        await Task.CompletedTask;
        _dbSet.Attach(entity);
    }

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate) {
        return predicate is null
            ? await _dbSet.CountAsync()
            : await _dbSet.CountAsync(predicate);
    }

    public async Task<long> LongCountAsync(Expression<Func<TEntity, bool>>? predicate) {
        return predicate is null
            ? await _dbSet.LongCountAsync()
            : await _dbSet.LongCountAsync(predicate);
    }
}


public class BaseRepository<TEntity>(ApplicationDbContext context) 
    : BaseRepository<TEntity, int>(context), IBaseRepository<TEntity>
    where TEntity : class;