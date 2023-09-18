using Book_Store.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book_Store.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("orders");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.TracingCode).HasMaxLength(300);

            builder.HasOne(o => o.User).WithMany(u => u.Orders).HasForeignKey(o => o.UserId).IsRequired();
        }
    }
}
