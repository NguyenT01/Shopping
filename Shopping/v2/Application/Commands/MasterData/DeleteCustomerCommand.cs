using AutoMapper;
using MediatR;

namespace Shopping.API.v2.Application.Commands.MasterData
{
    public class DeleteCustomerCommand : IRequest<Unit>
    {
        public Guid cid;
    }

    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly CustomerProto.CustomerProtoClient customerProto;

        public DeleteCustomerHandler(IMapper mapper, CustomerProto.CustomerProtoClient customerProto)
        {
            _mapper = mapper;
            this.customerProto = customerProto;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerIdRequest = new CustomerIdRequest
            {
                CustomerId = request.cid.ToString(),
                Tracking = false
            };
            await customerProto.DeleteCustomerAsync(customerIdRequest);

            return Unit.Value;
        }
    }
}
