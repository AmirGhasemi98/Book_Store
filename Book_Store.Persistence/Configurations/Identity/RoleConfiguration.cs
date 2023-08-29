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
                     ConcurrencyStamp = "9927413a-b476-494e-b98e-6937179e139e",
                     NormalizedName = "ADMINSTRATOR",
                 },
                new IdentityRole<int>
                {
                    Id = 2,
                    Name = "Employee",
                    ConcurrencyStamp = "c1cddc69-4abd-4ffb-a1a3-d95f08a9c5e7",
                    NormalizedName = "EMPLOYEE",
                }

                );
        }
    }
}
