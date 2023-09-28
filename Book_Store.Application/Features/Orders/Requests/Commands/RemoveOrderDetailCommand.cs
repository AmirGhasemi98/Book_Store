using Book_Store.Application.Responses;
using MediatR;

namespace Book_Store.Application.Features.Orders.Requests.Commands
{
    public class RemoveOrderDetailCommand : IRequest<BaseCommandResponse>
    {
        public int detailId { get; set; }

        public int UserId { get; set; }
    }
}
