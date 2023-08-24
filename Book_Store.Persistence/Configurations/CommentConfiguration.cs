using Book_Store.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book_Store.Persistence.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");

            builder.HasKey(c => c.Id);

            builder.Property(x => x.Text).IsRequired();

            builder.HasOne(c => c.Book).WithMany(b => b.Comments).HasForeignKey(c => c.Id).IsRequired();
            //builder.HasOne(c => c.User).WithMany(u => u.Comments).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.Cascade).IsRequired();
        }
    }
}
