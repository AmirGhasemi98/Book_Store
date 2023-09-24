using AutoMapper;
using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.Features.Orders.Requests.Commands;
using Book_Store.Domain.Entites;
using MediatR;

namespace Book_Store.Application.Features.Orders.Handlers.Commands
{
    public class AddBookToOpenOrderCommandHandler : IRequestHandler<AddBookToOpenOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public AddBookToOpenOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddBookToOpenOrderCommand request, CancellationToken cancellationToken)
        {
            var orderDetail = _mapper.Map<OrderDetail>(request.AddBookToOrder);

            await _orderRepository.AddProductToOpenOrder(request.UserId, orderDetail);

            return Unit.Value;
        }
    }
}
