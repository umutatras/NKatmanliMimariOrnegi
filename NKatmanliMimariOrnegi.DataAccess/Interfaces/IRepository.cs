using NKatmanliMimariOrnegi.SharedLibrary;
using System.Linq.Expressions;

namespace NKatmanliMimariOrnegi.DataAccess.Interfaces;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter);

    Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC);

    Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC);

    Task<T> FindAsync(object id);

    Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = false);

    IQueryable<T> GetQuery();

    void Remove(T entity);

    Task AddAsync(T entity);

    void Update(T entity);
}