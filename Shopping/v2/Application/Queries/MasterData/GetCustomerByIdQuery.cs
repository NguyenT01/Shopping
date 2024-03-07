using AutoMapper;
using MediatR;

namespace Shopping.API.v2.Application.Queries.MasterData
{
    public class GetCustomerByIdQuery : IRequest<CustomerResponse>
    {
        public Guid cid;
    }

    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, CustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly CustomerProto.CustomerProtoClient customerProto;

        public GetCustomerByIdHandler(IMapper mapper, CustomerProto.CustomerProtoClient customerProto)
        {
            _mapper = mapper;
            this.customerProto = customerProto;
        }

        public async Task<CustomerResponse> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
        {
            var customerIdRequest = new CustomerIdRequest
            {
                CustomerId = query.cid.ToString(),
                Tracking = false
            };
            var results = await customerProto.GetCustomerByIdAsync(customerIdRequest);
            return results;
        }

    }

}
