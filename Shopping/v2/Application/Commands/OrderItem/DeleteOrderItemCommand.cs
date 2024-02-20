using AutoMapper;
using MediatR;
using Shopping.API.Protos.Manager;

namespace Shopping.API.v2.Application.Commands.OrderItem
{
    public record DeleteOrderItemCommand : IRequest<Unit>
    {
        public Guid oid;
        public Guid pid;
    }

    public class DeleOrderItemHandler : IRequestHandler<DeleteOrderItemCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProtosManager Protos;

        public DeleOrderItemHandler(IMapper mapper, IProtosManager protos)
        {
            _mapper = mapper;
            Protos = protos;
        }

        public async Task<Unit> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
        {
            var itemRequest = new OrderItemDeletionRequest()
            {
                OrderId = request.oid.ToString(),
                ProductId = request.pid.ToString()
            };

            await Protos.OrderItem.DeleteOrderItemAsync(itemRequest);
            return Unit.Value;
        }
    }

}
