using Microsoft.EntityFrameworkCore;
using OrderingService.ORM.EF.Interface;
using OrderingService.ORM.EF.Model;

namespace OrderingService.ORM.EF
{
    public class OrderRepository : OrderingRepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(OrderingContext context) : base(context) { }
        public void CreateOrder(Order order)
            => Add(order);

        public void DeleteOrder(Order order)
            => Delete(order);

        public async Task<Order?> GetOrder(Guid oid, bool tracking)
            => await FindByCondition(ord => ord.OrderId.Equals(oid), tracking)
                    .SingleOrDefaultAsync();

        public async Task<IEnumerable<Order>> GetOrders(Guid customerId, bool tracking)
            => await FindByCondition(ord => ord.CustomerId.Equals(customerId), tracking)
                        .OrderBy(ord => ord.OrderDate)
                        .ToListAsync();
    }
}
