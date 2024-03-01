using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using MediatR;

namespace Shopping.API.v2.Application.Queries.MasterData
{
    public record GetCustomerListQuery : IRequest<CustomerListResponse> { }

    public class GetCustomerListHandler : IRequestHandler<GetCustomerListQuery, CustomerListResponse>
    {
        private readonly IMapper _mapper;
        private readonly CustomerProto.CustomerProtoClient customerProto;

        public GetCustomerListHandler(IMapper mapper, CustomerProto.CustomerProtoClient customerProto)
        {
            _mapper = mapper;
            this.customerProto = customerProto;
        }

        public async Task<CustomerListResponse> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            var results = await customerProto.GetCustomerListAsync(new Empty());
            return results;
        }
    }
}
