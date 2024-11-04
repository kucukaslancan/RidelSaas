using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Ridel.Application.Interfaces;
using Ridel.Persistence.Contexts;
using System.Linq.Expressions;

namespace Ridel.Persistence.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class, new()
    {
        protected readonly ApplicationDbContext _context;   
        private readonly Microsoft.EntityFrameworkCore.DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? expression)
        {
            return await (expression == null ? _dbSet.CountAsync() : _dbSet.CountAsync(expression));
        }

        public async Task<T> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            //await _context.SaveChangesAsync();
            return entity;
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression, bool enableTracking = false)
        {
            var query = _dbSet.Where(expression);
            return enableTracking ? query : query.AsNoTracking();
        }

        public async Task<IList<T>> GetAllAsync(
            Expression<Func<T, bool>>? expression = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool enableTracking = false)
        {
            IQueryable<T> query = _dbSet;

            if (expression != null)
                query = query.Where(expression);

            if (include != null)
                query = include(query);

            if (orderBy != null)
                query = orderBy(query);

            if (!enableTracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task<IList<T>> GetAllByPagingAsync(
            Expression<Func<T, bool>>? expression = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool enableTracking = false,
            int currentPage = 1,
            int pageSize = 10)
        {
            IQueryable<T> query = _dbSet;

            if (expression != null)
                query = query.Where(expression);

            if (include != null)
                query = include(query);

            if (orderBy != null)
                query = orderBy(query);

            if (!enableTracking)
                query = query.AsNoTracking();

            return await query
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<T> GetAsync(
            Expression<Func<T, bool>>? expression,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool enableTracking = false)
        {
            IQueryable<T> query = _dbSet;

            if (expression != null)
                query = query.Where(expression);

            if (include != null)
                query = include(query);

            if (!enableTracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            //await _context.SaveChangesAsync();
            return entity;
        }
    }
}
