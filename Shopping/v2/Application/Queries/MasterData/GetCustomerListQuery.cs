using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using MediatR;
using Shopping.API.Protos.Manager;

namespace Shopping.API.v2.Application.Queries.MasterData
{
    public record GetCustomerListQuery : IRequest<CustomerListResponse> { }

    public class GetCustomerListHandler : IRequestHandler<GetCustomerListQuery, CustomerListResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProtosManager Protos;

        public GetCustomerListHandler(IMapper mapper, IProtosManager protos)
        {
            _mapper = mapper;
            Protos = protos;
        }

        public async Task<CustomerListResponse> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            var results = await Protos.Customer.GetCustomerListAsync(new Empty());
            return results;
        }
    }
}
