using AutoMapper;
using MediatR;

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
        private readonly OrderItemProto.OrderItemProtoClient orderItemProto;

        public DeleOrderItemHandler(IMapper mapper, OrderItemProto.OrderItemProtoClient orderItemProto)
        {
            _mapper = mapper;
            this.orderItemProto = orderItemProto;
        }

        public async Task<Unit> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
        {
            var itemRequest = new OrderItemDeletionRequest()
            {
                OrderId = request.oid.ToString(),
                ProductId = request.pid.ToString()
            };

            await orderItemProto.DeleteOrderItemAsync(itemRequest);
            return Unit.Value;
        }
    }

}
