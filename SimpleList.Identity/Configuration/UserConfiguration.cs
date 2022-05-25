using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleList.Identity.Models;

namespace SimpleList.Identity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                new ApplicationUser 
                {
                    Id = "4adcad88-1cee-4cf3-9085-bf2b0562d4af",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "admin@localhost.com",
                    Name = "Admin 1",
                    Surname= "Test",
                    UserName = "admin",
                    NormalizedUserName = "admin",
                    PasswordHash = hasher.HashPassword(null, "admin1234"),
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    Id = "6966427c-6c38-4411-8f5a-76c91134ed58",
                    Email = "user@localhost.com",
                    NormalizedEmail = "user@localhost.com",
                    Name = "User 1",
                    Surname = "Test",
                    UserName = "user1",
                    NormalizedUserName = "user1",
                    PasswordHash = hasher.HashPassword(null, "user1234"),
                    EmailConfirmed = true
                }
            );
        }
    }
}
