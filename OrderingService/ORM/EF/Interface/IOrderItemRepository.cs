using OrderingService.ORM.EF.Model;

namespace OrderingService.ORM.EF.Interface
{
    public interface IOrderItemRepository
    {
        void AddItem(OrderItem item);
        void DeleteItem(OrderItem item);
        Task<OrderItem?> GetItem(Guid orderId, Guid productId, bool tracking);
        Task<IEnumerable<OrderItem>> GetItemFromAnOrder(Guid orderId, bool tracking);
    }

    public enum ItemStatus
    {
        Increment,
        Decrement
    }
}
