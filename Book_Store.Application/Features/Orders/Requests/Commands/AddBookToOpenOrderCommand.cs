using Book_Store.Application.DTOs.Order;
using Book_Store.Application.Responses;
using MediatR;

namespace Book_Store.Application.Features.Orders.Requests.Commands
{
    public class AddBookToOpenOrderCommand : IRequest<Unit>
    {
        public AddBookToOrderDto AddBookToOrder { get; set; }

        public int UserId { get; set; }
    }
}
