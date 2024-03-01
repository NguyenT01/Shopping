using AutoMapper;
using MediatR;

namespace Shopping.API.v2.Application.Commands.Order
{
    public class DeleteOrderCommand : IRequest<Unit>
    {
        public Guid oid;
    }

    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly OrderProto.OrderProtoClient orderProto;
        private readonly OrderItemProto.OrderItemProtoClient orderItemProto;

        public DeleteOrderHandler(IMapper mapper, OrderProto.OrderProtoClient orderProto, OrderItemProto.OrderItemProtoClient orderItemProto)
        {
            _mapper = mapper;
            this.orderProto = orderProto;
            this.orderItemProto = orderItemProto;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var orderItemRequest = new OrderItemIdRequest()
            {
                OrderId = request.oid.ToString()
            };
            var orderItems = await orderItemProto.GetItemsFromOrderAsync(orderItemRequest); ;

            if (orderItems.Items.Count > 0)
            {
                foreach (var item in orderItems.Items)
                {
                    var itemDeleteRequest = _mapper.Map<OrderItemDeletionRequest>(item);
                    await orderItemProto.DeleteOrderItemAsync(itemDeleteRequest);
                }
            }

            await orderProto.DeleteOrderAsync(_mapper.Map<OrderIdRequest>(orderItemRequest));
            return Unit.Value;
        }
    }

}
