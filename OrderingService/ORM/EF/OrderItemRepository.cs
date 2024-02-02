using Microsoft.EntityFrameworkCore;
using OrderingService.ORM.EF.Interface;
using OrderingService.ORM.EF.Model;

namespace OrderingService.ORM.EF
{
    public class OrderItemRepository : OrderingRepositoryBase<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(OrderingContext context) : base(context) { }
        public void AddItem(OrderItem item)
            => Add(item);

        public void DeleteItem(OrderItem item)
            => Delete(item);

        public async Task<OrderItem?> GetItem(Guid orderId, Guid productId, bool tracking)
            => await FindByCondition(o => o.OrderId.Equals(orderId) && o.ProductId.Equals(productId), tracking)
                    .SingleOrDefaultAsync();

        public async Task<IEnumerable<OrderItem>> GetItemFromAnOrder(Guid orderId, bool tracking)
            => await FindByCondition(o => o.OrderId.Equals(orderId), tracking)
                    .OrderBy(o => o.Quantity)
                    .ToListAsync();
    }
}
