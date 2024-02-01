using OrderingService.ORM.EF.Model;

namespace OrderingService.ORM.EF.Interface
{
    public interface IOrderRepository
    {
        Task<Order?> GetOrder(Guid oid, bool tracking);
        Task<IEnumerable<Order>> GetOrders(Guid customerId, bool tracking);
        void CreateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
