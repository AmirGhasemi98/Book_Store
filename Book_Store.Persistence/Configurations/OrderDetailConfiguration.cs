using Book_Store.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book_Store.Persistence.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails");

            builder.HasKey(o => o.Id);

            builder.HasOne(od => od.Order).WithMany(o => o.OrderDetails).HasForeignKey(o => o.OrderId).IsRequired();
            builder.HasOne(od => od.Book).WithMany(o => o.OrderDetails).HasForeignKey(o => o.BookId).IsRequired();
        }
    }
}
