using Dapper;
using ProductServiceNamespace.ORM.EF.Model;
using System.Data;

namespace ProductServiceNamespace.ORM.Dapper
{
    public class PriceDapper : IPriceDapper
    {
        private readonly IDbConnection _dbConnection;

        public PriceDapper(IDbConnection dbConnection) { _dbConnection = dbConnection; }

        public async Task<Price?> GetCurrentPrice(Guid productId)
        {
            var currentDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
            var query = @"SELECT * FROM [Price] 
                        WHERE ProductID = @pid AND (StartDate <= @cDate AND EndDate >= @cDate)
                        ORDER BY EndDate ASC, StartDate DESC ";
            var param = new { pid = productId, cDate = currentDate };
            var results = await _dbConnection.QueryFirstOrDefaultAsync<Price>(query, param);
            return results;
        }

        public async Task<Price?> GetPrice(Guid priceId)
        {
            var query = "SELECT * FROM [Price] WHERE PriceId = @pid";
            var param = new { pid = priceId };
            var results = await _dbConnection.QuerySingleOrDefaultAsync<Price>(query, param);
            return results;
        }

        public async Task<IEnumerable<Price>> GetPriceByRangeTime(Guid productId, DateTime startDate, DateTime endDate)
        {
            var query = @"SELECT * FROM [Price] 
                        WHERE ProductID = @pid AND (StartDate >= @sDate OR EndDate <= @eDate)
                        ORDER BY StartDate ASC, EndDate ASC";
            var param = new { pid = productId, sDate = startDate, eDate = endDate };
            var results = await _dbConnection.QueryAsync<Price>(query, param);
            return results;
        }

        public async Task<IEnumerable<Price>> GetPrices(Guid productId)
        {
            var query = @"SELECT * FROM [Price] 
                        WHERE ProductID = @pid
                        ORDER BY StartDate ASC, EndDate ASC";
            var param = new { pid = productId };
            var results = await _dbConnection.QueryAsync<Price>(query, param);
            return results;
        }
    }
}
