using Microsoft.EntityFrameworkCore;
using SimpleList.Application.Contracts.Persistence;
using SimpleList.Domain.Common;
using SimpleList.Infraestructure.Persistence;
using System.Linq.Expressions;

namespace SimpleList.Infraestructure.Repositories
{
    public class BaseRepository<T>:  IRepositoryAsync<T> where T: BaseDomainModel
    {
        private readonly ListsDBContext _context;

        public BaseRepository(ListsDBContext context)
        {
            _context = context;
        }

        public T AddEntity(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public bool DeleteEntity(T entity)
        {
            if (_context.Set<T>().Contains(entity)) 
            {
                _context.Set<T>().Remove(entity);
                return true;
            }

            return false;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>()
                .Where(predicate)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            string includeString = null, bool disabledTracking = true)
        {
            IQueryable<T> query = _context.Set<T>();

            if (disabledTracking)
            {
                query = query.AsNoTracking();
            }

            if (!string.IsNullOrWhiteSpace(includeString)) 
            {
                query.Include(includeString);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }

            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            List<Expression<Func<T, object>>> includes = null, bool disabledTracking = true)
        {
            IQueryable<T> query = _context.Set<T>();

            if (disabledTracking)
            {
                query = query.AsNoTracking();
            }

            if (includes?.Any() == true)
            {
                includes.Aggregate(query, (current, include) => current.Include(include));
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public T UpdateEntity(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            return entity;
        }
    }
}
