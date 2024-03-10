using Dapper;
using ProductServiceNamespace.ORM.EF.Model;
using System.Data;

namespace ProductServiceNamespace.ORM.Dapper
{
    public class ProductDapper : IProductDapper
    {
        private readonly IDbConnection _dbConnection;

        public ProductDapper(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var query = "SELECT * FROM [Products]";
            var results = await _dbConnection.QueryAsync<Product>(query);
            return results;
        }

        public async Task<Product?> GetProduct(Guid id)
        {
            var query = "SELECT * FROM [Products] WHERE ProductId = @pid";
            var command = new { pid = id };
            var results =  await _dbConnection.QuerySingleOrDefaultAsync<Product>(query, command);
            return results;
        }
    }
}
