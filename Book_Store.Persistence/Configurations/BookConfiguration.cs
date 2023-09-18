using Book_Store.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book_Store.Persistence.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title).HasMaxLength(100).IsRequired();
            builder.Property(b => b.Inventory).IsRequired();
            builder.Property(b => b.Description).IsRequired();
            builder.Property(b => b.Summary).IsRequired(false);

            builder.HasOne(b => b.Category).WithMany(c => c.Books).HasForeignKey(b => b.CategoryId).IsRequired();
            builder.HasOne(b => b.Publisher).WithMany(p => p.Books).HasForeignKey(b => b.PublisherId).IsRequired();
        }
    }
}
