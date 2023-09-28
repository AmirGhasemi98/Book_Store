using Book_Store.Application.DTOs.Order;
using MediatR;

namespace Book_Store.Application.Features.Orders.Requests.Queries
{
    public class GetUserOpenOrderDetailRequest : IRequest<UserOpenOrderDTO>
    {
        public int UserId { get; set; }
    }
}
