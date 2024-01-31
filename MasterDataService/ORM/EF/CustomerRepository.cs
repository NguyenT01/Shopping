using MasterDataService.ORM.EF.Interface;
using MasterDataService.ORM.EF.Model;
using Microsoft.EntityFrameworkCore;

namespace MasterDataService.ORM.EF;

public class CustomerRepository : MasterDataRepositoryBase<Customer>, ICustomerRepository
{
    // CONTRUCTOR
    public CustomerRepository(MasterDataContext context) : base(context) { }

    //METHODS
    public void CreateCustomer(Customer customer)
        => Add(customer);

    public void DeleteCustomer(Customer customer)
        => Delete(customer);

    public void UpdateCustomer(Customer customer)
       => Update(customer);

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync(bool tracking)
        => await FindAll(tracking)
                .OrderBy(cus => cus.FirstName)
                .ThenBy(cus => cus.LastName)
                .ToListAsync();

    public async Task<Customer?> GetCustomerAsync(Guid customerID, bool tracking)
        => await FindByCondition(cus => cus.CustomerId.Equals(customerID), tracking)
                .SingleOrDefaultAsync();
}
