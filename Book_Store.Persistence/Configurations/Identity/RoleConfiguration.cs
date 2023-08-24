using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book_Store.Persistence.Configurations.Identity
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<int>> builder)
        {
            builder.HasData(
                 new IdentityRole<int>
                 {
                     Id = 1,
                     Name = "Adminstrator",
                     NormalizedName = "ADMINSTRATOR",
                 },
                new IdentityRole<int>
                {
                    Id = 2,
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE",
                }

                );
        }
    }
}
