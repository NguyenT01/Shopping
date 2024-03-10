using OrderingService.ORM.EF.Model;

namespace OrderingService.ORM.Dapper
{
    public interface IOrderDapper
    {
        Task<IEnumerable<Order>> GetOrders(Guid customerId);
        Task<Order?> GetOrder(Guid orderId);
    }
}
