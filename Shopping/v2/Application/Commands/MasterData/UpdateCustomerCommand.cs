using AutoMapper;
using MediatR;
using Shopping.API.Dto;

namespace Shopping.API.v2.Application.Commands.MasterData
{
    public record UpdateCustomerCommand : IRequest<Unit>
    {
        public CustomerUpdateDTO? CustomerUpdateDTO;
    }
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly CustomerProto.CustomerProtoClient customerProto;

        public UpdateCustomerHandler(IMapper mapper, CustomerProto.CustomerProtoClient customerProto)
        {
            _mapper = mapper;
            this.customerProto = customerProto;
        }
        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerRequest = _mapper.Map<CustomerUpdateRequest>(request.CustomerUpdateDTO);
            await customerProto.UpdateCustomerAsync(customerRequest);

            return Unit.Value;
        }

    }

}
