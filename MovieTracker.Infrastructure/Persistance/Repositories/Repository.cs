using Microsoft.EntityFrameworkCore;
using MovieTracker.Application.Contracts.Repositories;
using MovieTracker.Infrastructure.Persistance.Contexts;
using System.Linq.Expressions;

namespace MovieTracker.Infrastructure.Persistance.Repositories;
public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        _context.SaveChanges();
    }

    public async Task AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public bool Any(Expression<Func<TEntity, bool>> predicate)
        => _context.Set<TEntity>().Any(predicate);

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        => await _context.Set<TEntity>().AnyAsync(predicate);

    //public bool DeleteId(Guid id)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<bool> DeleteIdAsync(Guid id)
    //{
    //    throw new NotImplementedException();
    //}

    public TEntity? Get(Expression<Func<TEntity, bool>> predicate)
        => _context.Set<TEntity>().FirstOrDefault();

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
        => await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);

    public TEntity? GetId(Guid id)
        => _context.Set<TEntity>().Find(id);

    public async Task<TEntity?> GetIdAsync(Guid id)
        => await _context.Set<TEntity>().FindAsync(id);

    public void Update(TEntity entity)
    {
        _context.Update(entity);
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _context.Update(entity);
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
