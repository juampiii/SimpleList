using Microsoft.EntityFrameworkCore;
using SimpleList.Domain;
using SimpleList.Domain.Common;

namespace SimpleList.Infraestructure.Persistence
{
    public class ListsDBContext : DbContext
    {
        public ListsDBContext(DbContextOptions<ListsDBContext> options) : base(options)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) 
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>()) 
            {
                switch (entry.State) 
                {
                    case EntityState.Added:
                        entry.Entity.CreationDate = DateTime.UtcNow;
                        //TODO: Get the userId from the context
                        entry.Entity.CreationUserId = 1;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        entry.Entity.LastModifiedUserId = 1;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<List>? Lists { get; set; }
    }
}
