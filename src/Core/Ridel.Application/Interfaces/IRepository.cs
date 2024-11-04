using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Ridel.Application.Interfaces
{
    public interface IRepository<T> where T : class,  new()
    {
        #region Read
        Task<IList<T>> GetAllAsync(
           Expression<Func<T, bool>>? expression = null,
           Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
           Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
           bool enableTracking = false
           );

        Task<IList<T>> GetAllByPagingAsync(
           Expression<Func<T, bool>>? expression = null,
           Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
           Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
           bool enableTracking = false,
           int currentPage = 1,
           int pageSize = 10
           );

        Task<T> GetAsync(
        Expression<Func<T, bool>>? expression,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        bool enableTracking = false
        );

        IQueryable<T> Find(Expression<Func<T, bool>> expression, bool enableTracking = false);

        Task<int> CountAsync(Expression<Func<T, bool>>? expression);
        #endregion

        #region write
        Task AddAsync(T entity);
        Task AddRangeAsync(IList<T> entities);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        #endregion
    }
}
