using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId = "167d787f-81b9-4efd-8b0c-2ee1097debec",
                    RoleId = "6d5212c2-2072-4d98-9616-bc49bab9577a"
                },
                 new IdentityUserRole<string>
                 {
                     UserId = "8d98883a-d2db-48a2-8154-b44e6d4af137",
                     RoleId = "66a4e6be-df4a-4440-ba48-05fe193182b0"
                 }
                );
        }
    }
}
