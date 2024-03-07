using Google.Protobuf.WellKnownTypes;
using MediatR;

namespace Shopping.API.v2.Application.Queries.MasterData
{
    public record GetCustomerListQuery : IRequest<CustomerListResponse> { }

    public class GetCustomerListHandler : IRequestHandler<GetCustomerListQuery, CustomerListResponse>
    {
        private readonly CustomerProto.CustomerProtoClient _customerClient;

        public GetCustomerListHandler(CustomerProto.CustomerProtoClient customerProto)
        {
            _customerClient = customerProto;
        }

        public async Task<CustomerListResponse> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            var results = await _customerClient.GetCustomerListAsync(new Empty());
            return results;
        }
    }
}
