using AutoMapper;
using MediatR;
using Shopping.API.Dto;
using Shopping.API.Protos.Manager;

namespace Shopping.API.v2.Application.Commands.MasterData
{
    public class CreateCustomerCommand : IRequest<CustomerResponse>
    {
        public CustomerCreationDTO? customerDTO;
    }

    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProtosManager Protos;

        public CreateCustomerHandler(IMapper mapper, IProtosManager protos)
        {
            _mapper = mapper;
            Protos = protos;
        }

        public async Task<CustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerRequest = _mapper.Map<CustomerCreationRequest>(request.customerDTO);
            var results = await Protos.Customer.CreateCustomerAsync(customerRequest);
            return results;
        }
    }
}
