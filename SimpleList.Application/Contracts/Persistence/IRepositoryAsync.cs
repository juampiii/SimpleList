using SimpleList.Domain.Common;

namespace SimpleList.Application.Contracts.Persistence
{
    public interface IRepositoryAsync<T> where T : BaseDomainModel
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}
