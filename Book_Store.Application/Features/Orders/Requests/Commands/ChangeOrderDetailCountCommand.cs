using Book_Store.Application.DTOs.Order;
using MediatR;

namespace Book_Store.Application.Features.Orders.Requests.Commands
{
    public class ChangeOrderDetailCountCommand : IRequest<Unit>
    {
        public OrderDetailCountDto DetailCountDto { get; set; }

        public int UserId { get; set; }
    }
}
