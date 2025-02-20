using System.Linq.Expressions;

namespace MovieTracker.Application.Contracts.Repositories;
public interface IRepository<TEntity>
{
    TEntity? GetId(Guid id);
    Task<TEntity?> GetIdAsync(Guid id);
    TEntity? Get(Expression<Func<TEntity, bool>> predicate); 
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate);
    bool Any(Expression<Func<TEntity, bool>> predicate);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
    void Add(TEntity entity);
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    Task UpdateAsync(TEntity entity);

    //bool DeleteId(Guid id);
    //Task<bool> DeleteIdAsync(Guid id);


}
