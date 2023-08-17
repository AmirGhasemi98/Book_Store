using Book_Store.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book_Store.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title).HasMaxLength(50).IsRequired();

            builder.HasOne(x => x.Parent).WithMany(c => c.Children).HasForeignKey(c => new { c.ParentId }).OnDelete(DeleteBehavior.Restrict).IsRequired(false);
        }
    }
}
