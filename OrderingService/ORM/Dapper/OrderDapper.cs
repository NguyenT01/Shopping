using Dapper;
using OrderingService.ORM.EF.Model;
using System.Data;

namespace OrderingService.ORM.Dapper
{
    public class OrderDapper : IOrderDapper
    {
        private readonly IDbConnection _dbConnection;

        public OrderDapper(IDbConnection connection) { _dbConnection = connection;}

        public async Task<Order?> GetOrder(Guid orderId)
        {
            var query = "SELECT * FROM [Order] WHERE OrderId = @orderId";
            var param = new { orderId = orderId };
            var result = await _dbConnection.QuerySingleOrDefaultAsync<Order>(query, param);
            return result;
        }

        public async Task<IEnumerable<Order>> GetOrders(Guid customerId)
        {
            var query = @"SELECT * 
                        FROM [Order]
                        WHERE CustomerId = @customerId
                        ORDER BY OrderDate ASC";
            var param = new { customerId = customerId };
            var results = await _dbConnection.QueryAsync<Order>(query, param);
            return results;
        
        }
    }
}
