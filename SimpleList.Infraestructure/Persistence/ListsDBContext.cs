using Microsoft.EntityFrameworkCore;
using SimpleList.Domain;

namespace SimpleList.Infraestructure.Persistence
{
    public class ListsDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost\sqlexpress; Initial Catalog=Lists;Integrated Security=True");
        }
        public DbSet<List>? Lists { get; set; }
    }
}
