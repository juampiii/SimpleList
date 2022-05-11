using SimpleList.Domain.Common;

namespace SimpleList.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryAsync<TEntity> GetRepository<TEntity>() where TEntity : BaseDomainModel;
        Task<int> Complete();

        // Custom Repositories
        IListRepositoryAsync ListRepository { get; }
    }
}
