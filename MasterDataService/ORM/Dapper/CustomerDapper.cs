using Dapper;
using MasterDataService.ORM.EF.Model;
using System.Data;

namespace MasterDataService.ORM.Dapper
{
    public class CustomerDapper : ICustomerDapper
    {
        private readonly IDbConnection _dbConnection;

        public CustomerDapper(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            var query = "SELECT * FROM [Customer]";
            var result = await _dbConnection.QueryAsync<Customer>(query);
            return result;
        }

        public async Task<Customer?> GetCustomer(Guid id)
        {
            var query = "SELECT * FROM [Customer] WHERE CustomerId = @pid";
            var param = new { pid = id };
            var result = await _dbConnection.QueryFirstOrDefaultAsync<Customer>(query, param);
            return result;
        }
    }
}
