using Dapper;
using OrderingService.ORM.EF.Model;
using System.Data;

namespace OrderingService.ORM.Dapper
{
    public class OrderItemDapper : IOrderItemDapper
    {
        private readonly IDbConnection _dbConnection;

        public OrderItemDapper(IDbConnection connection) { _dbConnection = connection;}

        public async Task<OrderItem?> GetItem(Guid orderId, Guid productId)
        {
            var query = "SELECT * FROM [OrderItem] WHERE OrderId = @orderId AND ProductId = @productId";
            var param = new { orderId = orderId, productId = productId };
            var results = await _dbConnection.QuerySingleOrDefaultAsync<OrderItem>(query, param);
            return results;
        }

        public async Task<IEnumerable<OrderItem>> GetItemFromAnOrder(Guid orderId)
        {
            var query = "SELECT * FROM [OrderItem] WHERE OrderId = @orderId ORDER BY Quantity ASC";
            var param = new { orderId = orderId };
            var results = await _dbConnection.QueryAsync<OrderItem>(query, param);
            return results;
        }
    }
}
