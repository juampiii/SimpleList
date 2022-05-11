using SimpleList.Application.Contracts.Persistence;
using SimpleList.Domain.Common;
using SimpleList.Infraestructure.Persistence;
using System.Collections;

namespace SimpleList.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ListsDBContext _context;
        private Hashtable _repositories;
        private IListRepositoryAsync _listRepositoryAsync;

        public IListRepositoryAsync ListRepository => _listRepositoryAsync ??= new ListRepositoryAsync(_context);

        public UnitOfWork(ListsDBContext dBContext) 
        {
            _context = dBContext;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IRepositoryAsync<TEntity> GetRepository<TEntity>() where TEntity : BaseDomainModel
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }
            var entityType = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(entityType)) 
            {
                var repositoryType = typeof(IRepositoryAsync<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(entityType, repositoryInstance);
            }

            return (IRepositoryAsync<TEntity>)_repositories;
        }
    }
}
