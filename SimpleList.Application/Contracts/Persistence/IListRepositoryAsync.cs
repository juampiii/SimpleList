using SimpleList.Domain;

namespace SimpleList.Application.Contracts.Persistence
{
    public interface IListRepositoryAsync: IRepositoryAsync<List>
    {
        Task<IReadOnlyList<List>> GetListsByUserIdAsync(int userId);
    }
}
