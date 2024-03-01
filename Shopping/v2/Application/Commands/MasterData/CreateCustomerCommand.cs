using AutoMapper;
using MediatR;
using Shopping.API.Dto;

namespace Shopping.API.v2.Application.Commands.MasterData
{
    public class CreateCustomerCommand : IRequest<CustomerResponse>
    {
        public CustomerCreationDTO? customerDTO;
    }

    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly CustomerProto.CustomerProtoClient customerProto;

        public CreateCustomerHandler(IMapper mapper, CustomerProto.CustomerProtoClient customerProto)
        {
            _mapper = mapper;
            this.customerProto = customerProto;
        }

        public async Task<CustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerRequest = _mapper.Map<CustomerCreationRequest>(request.customerDTO);
            var results = await customerProto.CreateCustomerAsync(customerRequest);
            return results;
        }
    }
}
