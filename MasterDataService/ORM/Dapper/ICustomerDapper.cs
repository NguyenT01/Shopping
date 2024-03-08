using MasterDataService.ORM.EF.Model;

namespace MasterDataService.ORM.Dapper
{
    public interface ICustomerDapper
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer?> GetCustomer(Guid id);
    }
}
