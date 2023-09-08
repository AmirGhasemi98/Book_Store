using Book_Store.Domain.Common;
using Book_Store.Domain.Entites;
using Book_Store.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Persistence
{
    public class BookStoreDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<BookImage> BookImages { get; set; }

        public DbSet<BookMapAuthor> BookMapAuthors { get; set; }

        public DbSet<Translator> Translators { get; set; }

        public DbSet<BookMapTranslator> BookMapTranslators { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookStoreDbContext).Assembly);

            //modelBuilder.ApplyConfiguration(new RoleConfiguration());
            //modelBuilder.ApplyConfiguration(new UserConfiguration());
            //modelBuilder.ApplyConfiguration(new UserRoleConfiguration());


        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {


            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                if (entry.State == EntityState.Modified)
                    entry.Entity.ModifiedDate = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.UtcNow;
                    entry.Entity.CreatedBy = "Amir";
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                if (entry.State == EntityState.Modified)
                    entry.Entity.ModifiedDate = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                    entry.Entity.DateCreated = DateTime.UtcNow;
            }

            return base.SaveChanges();
        }

    }
}
