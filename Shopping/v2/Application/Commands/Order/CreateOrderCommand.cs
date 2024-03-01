using AutoMapper;
using MediatR;
using Shopping.API.Dto;

namespace Shopping.API.v2.Application.Commands.Order
{
    public class CreateOrderCommand : IRequest<OrderDTO>
    {
        public OrderCreationDTO? orderCreationDTO;
    }

    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, OrderDTO>
    {
        private readonly IMapper _mapper;
        private readonly OrderProto.OrderProtoClient orderProto;
        private readonly OrderItemProto.OrderItemProtoClient orderItemProto;

        public CreateOrderHandler(IMapper mapper, OrderProto.OrderProtoClient orderProto, OrderItemProto.OrderItemProtoClient orderItemProto)
        {
            _mapper = mapper;
            this.orderProto = orderProto;
            this.orderItemProto = orderItemProto;
        }

        public async Task<OrderDTO> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderRequest = _mapper.Map<OrderCreationRequest>(request.orderCreationDTO);
            var order = await orderProto.CreateOrderAsync(orderRequest);

            var orderItemRequests = _mapper.Map<IList<OrderItemCreationRequest>>(request.orderCreationDTO!.Items);

            for (int i = 0; i < orderItemRequests.Count(); i++)
            {
                orderItemRequests[i].OrderId = order.OrderId;
                await orderItemProto.CreateOrderItemAsync(orderItemRequests[i]);
            }

            return _mapper.Map<OrderDTO>(order);
        }
    }

}
