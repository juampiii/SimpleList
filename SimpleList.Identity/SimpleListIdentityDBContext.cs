using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleList.Identity.Configuration;
using SimpleList.Identity.Models;

namespace SimpleList.Identity
{
    public class SimpleListIdentityDBContext: IdentityDbContext<ApplicationUser>
    {
        public SimpleListIdentityDBContext(DbContextOptions<SimpleListIdentityDBContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
