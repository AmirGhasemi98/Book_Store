using Book_Store.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book_Store.Persistence.Configurations
{
    public class BookImageConfiguration : IEntityTypeConfiguration<BookImage>
    {
        public void Configure(EntityTypeBuilder<BookImage> builder)
        {
            builder.ToTable("BookImages");

            builder.HasKey(i => i.Id);

            builder.HasOne(i => i.Book).WithMany(b => b.BookImages).HasForeignKey(i => i.BookId);
        }
    }
}
