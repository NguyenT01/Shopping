using AutoMapper;
using MediatR;
using Shopping.API.Protos.Manager;

namespace Shopping.API.v2.Application.Queries.MasterData
{
    public class GetCustomerByIdQuery : IRequest<CustomerResponse>
    {
        public Guid cid;
    }

    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, CustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProtosManager Protos;

        public GetCustomerByIdHandler(IMapper mapper, IProtosManager protos)
        {
            _mapper = mapper;
            Protos = protos;
        }

        public async Task<CustomerResponse> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
        {
            var customerIdRequest = new CustomerIdRequest
            {
                CustomerId = query.cid.ToString(),
                Tracking = false
            };
            var results = await Protos.Customer.GetCustomerByIdAsync(customerIdRequest);
            return results;
        }

    }

}
