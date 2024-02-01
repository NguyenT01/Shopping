using OrderingService.ORM.EF.Interface;

namespace OrderingService.ORM.EF
{
    public class OrderingRepositoryManager : IOrderingRepositoryManager
    {
        private readonly OrderingContext context;
        private readonly IOrderRepository OrderRepository;
        public IOrderRepository Order => OrderRepository;

        public OrderingRepositoryManager(OrderingContext context)
        {
            this.context = context;
            OrderRepository = new OrderRepository(context);
        }

        public async Task SaveAsync()
            => await context.SaveChangesAsync();
    }
}
