using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleList.Identity.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "5c66ea83-8ddc-407b-98a5-a0a02117cc2f",
                    UserId = "4adcad88-1cee-4cf3-9085-bf2b0562d4af"
                    
                },
                new IdentityUserRole<string>
                {
                    RoleId = "4343105c-5833-4d58-ae0c-8045fa447945",
                    UserId = "6966427c-6c38-4411-8f5a-76c91134ed58"
                }
            );
        }
    }
}
