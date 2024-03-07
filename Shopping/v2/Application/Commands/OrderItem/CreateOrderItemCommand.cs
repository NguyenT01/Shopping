using AutoMapper;
using MediatR;
using Shopping.API.Dto;

namespace Shopping.API.v2.Application.Commands.OrderItem
{
    public class CreateOrderItemCommand : IRequest<OrderItemDTO>
    {
        public Guid oid;
        public OrderItemCreationWithoutOrderId? orderItemCreationWithoutOrderId;
    }

    public class CreateOrderItemHandler : IRequestHandler<CreateOrderItemCommand, OrderItemDTO>
    {
        private readonly IMapper _mapper;
        private readonly OrderItemProto.OrderItemProtoClient orderItemProto;

        public CreateOrderItemHandler(IMapper mapper, OrderItemProto.OrderItemProtoClient orderItemProto)
        {
            _mapper = mapper;
            this.orderItemProto = orderItemProto;
        }

        public async Task<OrderItemDTO> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<OrderItemCreationRequest>(request.orderItemCreationWithoutOrderId);
            item.OrderId = request.oid.ToString();

            var itemResponse = await orderItemProto.CreateOrderItemAsync(item);
            return _mapper.Map<OrderItemDTO>(itemResponse);
        }
    }

}
