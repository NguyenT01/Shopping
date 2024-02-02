using OrderingService.ORM.EF.Interface;

namespace OrderingService.ORM.EF
{
    public class OrderingRepositoryManager : IOrderingRepositoryManager
    {
        private readonly OrderingContext context;
        private readonly IOrderRepository OrderRepository;
        private readonly IOrderItemRepository OrderItemRepository;

        public IOrderRepository Order => OrderRepository;

        public IOrderItemRepository OrderItem => OrderItemRepository;

        public OrderingRepositoryManager(OrderingContext context)
        {
            this.context = context;
            OrderRepository = new OrderRepository(context);
            OrderItemRepository = new OrderItemRepository(context);
        }

        public async Task SaveAsync()
            => await context.SaveChangesAsync();
    }
}
