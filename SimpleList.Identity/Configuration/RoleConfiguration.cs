using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimpleList.Identity.Configuration
{
    internal class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "5c66ea83-8ddc-407b-98a5-a0a02117cc2f",
                    Name = "Administrator",
                    NormalizedName = "Administrator"
                },
                new IdentityRole
                {
                    Id = "4343105c-5833-4d58-ae0c-8045fa447945",
                    Name = "Operator",
                    NormalizedName = "Operator"
                }
            );
        }
    }
}
