using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.Features.Orders.Requests.Commands;
using Book_Store.Application.Responses;
using MediatR;

namespace Book_Store.Application.Features.Orders.Handlers.Commands
{
    public class RemoveOrderDetailCommandHandler : IRequestHandler<RemoveOrderDetailCommand, BaseCommandResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public RemoveOrderDetailCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<BaseCommandResponse> Handle(RemoveOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var result = await _orderRepository.RemoveOrderDetail(request.detailId, request.UserId);

            if (result)
            {
                response.Success = true;
                response.Message = "عملیات با موفقیت انجام شد.";

                return response;
            }

            response.Success = false;
            response.Message = "خطا در انجام عملیات";
            response.Errors.Add("خطا در انجام عملیات");

            return response;

        }
    }
}
