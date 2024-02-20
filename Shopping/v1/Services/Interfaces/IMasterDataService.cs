using Shopping.API.Dto;

namespace Shopping.API.v1.Services.Interfaces
{
    public interface IMasterDataService
    {
        Task<CustomerListResponse> GetCustomerList();
        Task<CustomerResponse> GetCustomerById(Guid cid);
        Task DeleteCustomer(Guid cid);
        Task<CustomerResponse?> CreateCustomer(CustomerCreationDTO customerDTO);
        Task UpdateCustomer(CustomerUpdateDTO customerDTO);
    }
}
