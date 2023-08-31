using Book_Store.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book_Store.Persistence.Configurations
{
    public class BookMapTranslatorConfiguration : IEntityTypeConfiguration<BookMapTranslator>
    {
        public void Configure(EntityTypeBuilder<BookMapTranslator> builder)
        {
            builder.ToTable("BookMapTranslators");

            builder.HasKey(x => new { x.BookId, x.TransLatorId });

            builder.HasOne(x => x.Book).WithMany(b => b.bookMapTranslators).HasForeignKey(x => x.BookId).IsRequired();
            builder.HasOne(x => x.Translator).WithMany(a => a.bookMapTranslators).HasForeignKey(x => x.TransLatorId).IsRequired();
        }
    }
}
