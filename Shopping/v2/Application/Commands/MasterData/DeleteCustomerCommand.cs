using AutoMapper;
using MediatR;
using Shopping.API.Protos.Manager;

namespace Shopping.API.v2.Application.Commands.MasterData
{
    public class DeleteCustomerCommand : IRequest<Unit>
    {
        public Guid cid;
    }

    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProtosManager Protos;

        public DeleteCustomerHandler(IMapper mapper, IProtosManager protos)
        {
            _mapper = mapper;
            Protos = protos;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerIdRequest = new CustomerIdRequest
            {
                CustomerId = request.cid.ToString(),
                Tracking = false
            };
            await Protos.Customer.DeleteCustomerAsync(customerIdRequest);

            return Unit.Value;
        }
    }
}
