using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.DTOs.Order;
using Book_Store.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Persistence.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly BookStoreDbContext _context;

        public OrderRepository(BookStoreDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Order> GetUserLatestOpenOrder(int userId)
        {
            if (!await _context.Orders.AnyAsync(o => o.UserId == userId && !o.IsPaid))
            {
                var order = new Order
                {
                    UserId = userId,
                };

                await Add(order);
            }

            var userOpenOrder = await _context.Orders
                                     .Include(o => o.OrderDetails).ThenInclude(od => od.Book)
                                     .SingleOrDefaultAsync(o => o.UserId == userId && !o.IsPaid);

            return userOpenOrder;

        }

        public async Task AddProductToOpenOrder(int userId, AddBookToOrderDto order)
        {
            var openOrder = await GetUserLatestOpenOrder(userId);

            var similarOrder = openOrder.OrderDetails.SingleOrDefault(o => o.BookId == order.BookId);

            if (similarOrder is null)
            {
                var orderDetail = new OrderDetail
                {
                    OrderId = openOrder.Id,
                    BookId = order.BookId,
                    Count = order.Count
                };

                await _context.OrderDetails.AddAsync(orderDetail);
                await _context.SaveChangesAsync();
            }
            else
            {
                similarOrder.Count = order.Count;
                await _context.SaveChangesAsync();
            }
        }
    }
}
