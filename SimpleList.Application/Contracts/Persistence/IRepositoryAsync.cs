using SimpleList.Domain.Common;
using System.Linq.Expressions;

namespace SimpleList.Application.Contracts.Persistence
{
    public interface IRepositoryAsync<T> where T : BaseDomainModel
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IReadOnlyList<T>> GetAsync(
            Expression<Func<T, bool>> predicate= null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeString=null,
            bool disabledTracking = true);

        Task<IReadOnlyList<T>> GetAsync(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<Expression<Func<T, object>>> includes = null,
            bool disabledTracking = true);
        Task<T> GetByIdAsync(int id);
        T AddEntity(T entity);
        T UpdateEntity(T entity);
        bool DeleteEntity(T entity);
        //TODO: en implementación del UnitOfWork mover este método
        Task SaveChangesAsync();
    }
}
