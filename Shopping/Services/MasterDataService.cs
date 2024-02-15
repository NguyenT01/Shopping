using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Shopping.API.Dto;
using Shopping.API.Services.Interfaces;

namespace Shopping.API.Services
{
    public class MasterDataService : IMasterDataService
    {
        private readonly IMapper _mapper;
        private readonly CustomerProto.CustomerProtoClient CustomerProto;

        public MasterDataService(IMapper mapper, CustomerProto.CustomerProtoClient customerProto)
        {
            _mapper = mapper;
            CustomerProto = customerProto;
        }

        public async Task DeleteCustomer(Guid cid)
        {
            var customerIdRequest = new CustomerIdRequest
            {
                CustomerId = cid.ToString(),
                Tracking = false
            };
            await CustomerProto.DeleteCustomerAsync(customerIdRequest);
        }

        public async Task<CustomerResponse?> CreateCustomer(CustomerCreationDTO customerDTO)
        {
            var customerRequest = _mapper.Map<CustomerCreationRequest>(customerDTO);
            var results = await CustomerProto.CreateCustomerAsync(customerRequest);
            return results;
        }

        public async Task<CustomerResponse> GetCustomerById(Guid cid)
        {
            var customerIdRequest = new CustomerIdRequest
            {
                CustomerId = cid.ToString(),
                Tracking = false
            };
            var results = await CustomerProto.GetCustomerByIdAsync(customerIdRequest);
            return results;
        }

        public async Task<CustomerListResponse> GetCustomerList()
        {
            var results = await CustomerProto.GetCustomerListAsync(new Empty());
            return results;
        }

        public async Task UpdateCustomer(CustomerUpdateDTO customerDTO)
        {
            var customerRequest = _mapper.Map<CustomerUpdateRequest>(customerDTO);
            await CustomerProto.UpdateCustomerAsync(customerRequest);
        }
    }
}
