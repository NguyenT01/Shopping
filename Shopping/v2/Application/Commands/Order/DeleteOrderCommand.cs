using AutoMapper;
using MediatR;
using Shopping.API.Protos.Manager;

namespace Shopping.API.v2.Application.Commands.Order
{
    public class DeleteOrderCommand : IRequest<Unit>
    {
        public Guid oid;
    }

    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProtosManager Protos;

        public DeleteOrderHandler(IMapper mapper, IProtosManager protos)
        {
            _mapper = mapper;
            Protos = protos;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var orderItemRequest = new OrderItemIdRequest()
            {
                OrderId = request.oid.ToString()
            };
            var orderItems = await Protos.OrderItem.GetItemsFromOrderAsync(orderItemRequest); ;

            if (orderItems.Items.Count > 0)
            {
                foreach (var item in orderItems.Items)
                {
                    var itemDeleteRequest = _mapper.Map<OrderItemDeletionRequest>(item);
                    await Protos.OrderItem.DeleteOrderItemAsync(itemDeleteRequest);
                }
            }

            await Protos.Order.DeleteOrderAsync(_mapper.Map<OrderIdRequest>(orderItemRequest));
            return Unit.Value;
        }
    }

}
