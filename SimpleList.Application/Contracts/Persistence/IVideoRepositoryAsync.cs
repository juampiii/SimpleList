using SimpleList.Domain;

namespace SimpleList.Application.Contracts.Persistence
{
    public interface IVideoRepositoryAsync: IRepositoryAsync<List>
    {
        Task<IReadOnlyList<List>> GetListsByUserIdAsync(int userId);
    }
}
