using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.Features.Orders.Requests.Commands;
using MediatR;

namespace Book_Store.Application.Features.Orders.Handlers.Commands
{
    public class ChangeOrderDetailCountCommandHandler : IRequestHandler<ChangeOrderDetailCountCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;

        public ChangeOrderDetailCountCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(ChangeOrderDetailCountCommand request, CancellationToken cancellationToken)
        {
            await _orderRepository.ChangeOrderDetailCount(request.DetailCountDto, request.UserId);

            return Unit.Value;
        }
    }
}
