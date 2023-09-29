using Book_Store.Application.DTOs.Order;
using Book_Store.Domain.Entites;
using System.Threading.Tasks;

namespace Book_Store.Application.Contracts.Persistence
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order> GetUserLatestOpenOrder(int userId);

        Task AddProductToOpenOrder(int userId, OrderDetail order);

        Task<Order> GetUserOpenOrderDetail(int userId);

        Task ChangeOrderDetailCount(OrderDetailCountDto detailCountDto, int userId);

        Task<bool> RemoveOrderDetail(int detailId, int userId);

        void DeleteLastOrders();
    }
}
