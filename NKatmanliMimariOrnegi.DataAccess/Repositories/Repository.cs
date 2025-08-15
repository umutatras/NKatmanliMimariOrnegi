using Microsoft.EntityFrameworkCore;
using NKatmanliMimariOrnegi.DataAccess.Contexts;
using NKatmanliMimariOrnegi.DataAccess.Interfaces;
using NKatmanliMimariOrnegi.Entities;
using NKatmanliMimariOrnegi.SharedLibrary;
using System.Linq.Expressions;

namespace NKatmanliMimariOrnegi.DataAccess.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly NKatmanliMimariOrnegiDbContext _context;

    public Repository(NKatmanliMimariOrnegiDbContext context)
    {
        _context = context;
    }


    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
    {
        return await _context.Set<T>().Where(filter).AsNoTracking().ToListAsync();
    }

    public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC)
    {
        return orderByType == OrderByType.ASC ? await _context.Set<T>().AsNoTracking().OrderBy(selector).ToListAsync() : await _context.Set<T>().AsNoTracking().OrderByDescending(selector).ToListAsync();
    }

    public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC)
    {
        return orderByType == OrderByType.ASC ? await _context.Set<T>().Where(filter).AsNoTracking().OrderBy(selector).ToListAsync() : await _context.Set<T>().Where(filter).AsNoTracking().OrderByDescending(selector).ToListAsync();
    }

    public async Task<T> FindAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<T> GetById(int id)
    {
        return await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }

    public IQueryable<T> GetQuery()
    {
        return _context.Set<T>().AsQueryable();
    }

    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();

    }

    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}