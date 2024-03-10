using OrderingService.ORM.EF.Model;

namespace OrderingService.ORM.Dapper
{
    public interface IOrderItemDapper
    {
        Task<IEnumerable<OrderItem>> GetItemFromAnOrder(Guid orderId);
        Task<OrderItem?> GetItem(Guid orderId, Guid productId);
    }
}
