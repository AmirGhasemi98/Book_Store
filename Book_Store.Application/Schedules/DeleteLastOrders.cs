using Book_Store.Application.Contracts.Persistence;
using Quartz;

namespace Book_Store.Application.Schedules
{
    [DisallowConcurrentExecution]
    public class DeleteLastOrders : IJob
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteLastOrders(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task Execute(IJobExecutionContext context)
        {
             _orderRepository.DeleteLastOrders();

            return Task.FromResult(true);
        }
    }
}
