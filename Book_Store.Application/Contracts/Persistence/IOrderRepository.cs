using Book_Store.Application.DTOs.Order;
using Book_Store.Domain.Entites;

namespace Book_Store.Application.Contracts.Persistence
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order> GetUserLatestOpenOrder(int userId);

        Task AddProductToOpenOrder(int userId, OrderDetail order);

        Task ChangeOrderDetailCount(OrderDetailCountDto detailCountDto, int userId);

        Task<bool> RemoveOrderDetail(int detailId, int userId);
    }
}
