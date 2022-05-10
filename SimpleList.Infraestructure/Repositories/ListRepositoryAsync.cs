using SimpleList.Application.Contracts.Persistence;
using SimpleList.Domain;
using SimpleList.Infraestructure.Persistence;

namespace SimpleList.Infraestructure.Repositories
{
    public class ListRepositoryAsync : BaseRepository<List>, IListRepositoryAsync
    {
        private readonly ListsDBContext _context;

        public ListRepositoryAsync(ListsDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Domain.List>> GetListsByUserIdAsync(int userId)
        {
            return await GetAsync(u => u.CreationUserId == userId);
        }
    }
}
