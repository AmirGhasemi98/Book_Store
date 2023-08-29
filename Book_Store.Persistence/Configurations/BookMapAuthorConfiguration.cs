using Book_Store.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book_Store.Persistence.Configurations
{
    public class BookMapAuthorConfiguration : IEntityTypeConfiguration<BookMapAuthor>
    {
        public void Configure(EntityTypeBuilder<BookMapAuthor> builder)
        {
            builder.ToTable("BookMapAuthors");

            builder.HasKey(x => new { x.BookId, x.AuthorId });

            builder.HasOne(x => x.Book).WithMany(b => b.bookMapAuthors).HasForeignKey(x => x.BookId).IsRequired();
            builder.HasOne(x => x.Author).WithMany(a => a.BookMapAuthors).HasForeignKey(x => x.AuthorId).IsRequired();
        }
    }
}
