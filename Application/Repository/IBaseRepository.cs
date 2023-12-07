namespace Application.Repository; 

public interface IBaseRepository <TEntity, in TKey> :
    IBaseRepositorySync<TEntity, TKey>,
    IBaseRepositoryAsync<TEntity, TKey>
    where TEntity : class;
    
    
public interface IBaseRepository <TEntity> :
    IBaseRepositorySync<TEntity, int>,
    IBaseRepositoryAsync<TEntity, int>
    where TEntity : class;
