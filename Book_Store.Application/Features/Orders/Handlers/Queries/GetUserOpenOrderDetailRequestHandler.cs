using AutoMapper;
using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.DTOs.Order;
using Book_Store.Application.Features.Orders.Requests.Queries;
using MediatR;

namespace Book_Store.Application.Features.Orders.Handlers.Queries
{
    public class GetUserOpenOrderDetailRequestHandler : IRequestHandler<GetUserOpenOrderDetailRequest, UserOpenOrderDTO>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetUserOpenOrderDetailRequestHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<UserOpenOrderDTO> Handle(GetUserOpenOrderDetailRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetUserOpenOrderDetail(request.UserId);
            return _mapper.Map<UserOpenOrderDTO>(order);
        }
    }
}
