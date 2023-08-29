using Book_Store.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book_Store.Persistence.Configurations.Identity
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                new ApplicationUser
                {
                    Id = 1,
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    FirstName = "Admin",
                    LastName = "Adminian",
                    UserName = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    // PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    PasswordHash = "AQAAAAEAACcQAAAAECPynJtQ4+4V1730o7BjrE0kmmb+csq8jQkN93XuOJr/Vlmn7lI54RUG33JYrJuv3w==",
                    EmailConfirmed = true,
                    ConcurrencyStamp = "e1697e5e-1e17-44a7-821f-f1f9737f4d33",
                    SecurityStamp = "e943ea3c-33e2-49c0-be3e-2c587f87739a"
                },
                new ApplicationUser
                {
                    Id = 2,
                    Email = "user@localhost.com",
                    NormalizedEmail = "USER@LOCALHOST.COM",
                    FirstName = "System",
                    LastName = "User",
                    UserName = "user@localhost.com",
                    NormalizedUserName = "USER@LOCALHOST.COM",
                    //PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    PasswordHash = "AQAAAAEAACcQAAAAEDbvjqvyZtSSAMK6ihKa2AIc4BYpivHr3N2s9ZU1GfDhTE5jcdMTpItxjUvo2rldtg==",
                    EmailConfirmed = true,
                    ConcurrencyStamp = "231df1fc-4a14-40f9-ba0d-349de2ac7968",
                    SecurityStamp = "a0e7bb30-2bd4-455e-a645-30c8fb64bbcf"
                }
                );
        }
    }
}
