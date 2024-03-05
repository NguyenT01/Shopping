using Google.Protobuf.WellKnownTypes;
using Grpc.Net.ClientFactory;
using MediatR;

namespace Shopping.API.v2.Application.Queries.MasterData
{
    public record GetCustomerListQuery : IRequest<CustomerListResponse> { }

    public class GetCustomerListHandler : IRequestHandler<GetCustomerListQuery, CustomerListResponse>
    {
        private readonly CustomerProto.CustomerProtoClient _customerClient;

        public GetCustomerListHandler(GrpcClientFactory grpcClientFactor)
        {
            _customerClient = grpcClientFactor.CreateClient<CustomerProto.CustomerProtoClient>("masterdata");
        }

        public async Task<CustomerListResponse> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            var results = await _customerClient.GetCustomerListAsync(new Empty());
            return results;
        }
    }
}
