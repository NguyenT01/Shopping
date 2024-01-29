using MasterDataService.ORM.EF.Model;

namespace MasterDataService.ORM.EF.Interface;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetAllCustomersAsync(bool tracking);
    Task<Customer?> GetCustomerAsync(Guid customerID, bool tracking);
    void CreateCustomer(Customer customer);
    void DeleteCustomer(Customer customer);

    void Update(Customer customer);

}
