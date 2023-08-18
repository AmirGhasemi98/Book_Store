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
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id= "66a4e6be-df4a-4440-ba48-05fe193182b0",
                    Name = "Employee",
                    NormalizedName="EMPLOYEE",
                },
                 new IdentityRole
                 {
                     Id = "6d5212c2-2072-4d98-9616-bc49bab9577a",
                     Name = "Adminstrator",
                     NormalizedName = "ADMINSTRATOR",
                 }
                );
        }
    }
}
