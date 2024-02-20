using AutoMapper;
using MediatR;
using Shopping.API.Dto;
using Shopping.API.Protos.Manager;

namespace Shopping.API.v2.Application.Commands.MasterData
{
    public record UpdateCustomerCommand : IRequest<Unit>
    {
        public CustomerUpdateDTO? CustomerUpdateDTO;
    }
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProtosManager Protos;

        public UpdateCustomerHandler(IMapper mapper, IProtosManager protos)
        {
            _mapper = mapper;
            Protos = protos;
        }
        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerRequest = _mapper.Map<CustomerUpdateRequest>(request.CustomerUpdateDTO);
            await Protos.Customer.UpdateCustomerAsync(customerRequest);

            return Unit.Value;
        }

    }

}
