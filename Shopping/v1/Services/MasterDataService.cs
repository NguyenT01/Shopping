using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Shopping.API.Dto;
using Shopping.API.v1.Services.Interfaces;

namespace Shopping.API.v1.Services
{
    public class MasterDataService : IMasterDataService
    {
        private readonly IMapper _mapper;
        private readonly CustomerProto.CustomerProtoClient customerProto;

        public MasterDataService(IMapper mapper, CustomerProto.CustomerProtoClient customerProto)
        {
            _mapper = mapper;
            this.customerProto = customerProto;
        }

        public async Task DeleteCustomer(Guid cid)
        {
            var customerIdRequest = new CustomerIdRequest
            {
                CustomerId = cid.ToString(),
                Tracking = false
            };
            await customerProto.DeleteCustomerAsync(customerIdRequest);
        }

        public async Task<CustomerResponse?> CreateCustomer(CustomerCreationDTO customerDTO)
        {
            var customerRequest = _mapper.Map<CustomerCreationRequest>(customerDTO);
            var results = await customerProto.CreateCustomerAsync(customerRequest);
            return results;
        }

        public async Task<CustomerResponse> GetCustomerById(Guid cid)
        {
            var customerIdRequest = new CustomerIdRequest
            {
                CustomerId = cid.ToString(),
                Tracking = false
            };
            var results = await customerProto.GetCustomerByIdAsync(customerIdRequest);
            return results;
        }

        public async Task<CustomerListResponse> GetCustomerList()
        {
            var results = await customerProto.GetCustomerListAsync(new Empty());
            return results;
        }

        public async Task UpdateCustomer(CustomerUpdateDTO customerDTO)
        {
            var customerRequest = _mapper.Map<CustomerUpdateRequest>(customerDTO);
            await customerProto.UpdateCustomerAsync(customerRequest);
        }
    }
}
