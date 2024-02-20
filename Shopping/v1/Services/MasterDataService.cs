using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Shopping.API.Dto;
using Shopping.API.Protos.Manager;
using Shopping.API.v1.Services.Interfaces;

namespace Shopping.API.v1.Services
{
    public class MasterDataService : IMasterDataService
    {
        private readonly IMapper _mapper;
        private readonly IProtosManager Protos;

        public MasterDataService(IMapper mapper, IProtosManager protos)
        {
            _mapper = mapper;
            Protos = protos;
        }

        public async Task DeleteCustomer(Guid cid)
        {
            var customerIdRequest = new CustomerIdRequest
            {
                CustomerId = cid.ToString(),
                Tracking = false
            };
            await Protos.Customer.DeleteCustomerAsync(customerIdRequest);
        }

        public async Task<CustomerResponse?> CreateCustomer(CustomerCreationDTO customerDTO)
        {
            var customerRequest = _mapper.Map<CustomerCreationRequest>(customerDTO);
            var results = await Protos.Customer.CreateCustomerAsync(customerRequest);
            return results;
        }

        public async Task<CustomerResponse> GetCustomerById(Guid cid)
        {
            var customerIdRequest = new CustomerIdRequest
            {
                CustomerId = cid.ToString(),
                Tracking = false
            };
            var results = await Protos.Customer.GetCustomerByIdAsync(customerIdRequest);
            return results;
        }

        public async Task<CustomerListResponse> GetCustomerList()
        {
            var results = await Protos.Customer.GetCustomerListAsync(new Empty());
            return results;
        }

        public async Task UpdateCustomer(CustomerUpdateDTO customerDTO)
        {
            var customerRequest = _mapper.Map<CustomerUpdateRequest>(customerDTO);
            await Protos.Customer.UpdateCustomerAsync(customerRequest);
        }
    }
}
