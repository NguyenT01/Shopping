using AutoMapper;
using MediatR;
using Shopping.API.Dto;
using Shopping.API.Protos.Manager;

namespace Shopping.API.v2.Application.Commands.Order
{
    public class CreateOrderCommand : IRequest<OrderDTO>
    {
        public OrderCreationDTO? orderCreationDTO;
    }

    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, OrderDTO>
    {
        private readonly IMapper _mapper;
        private readonly IProtosManager Protos;

        public CreateOrderHandler(IMapper mapper, IProtosManager protos)
        {
            _mapper = mapper;
            Protos = protos;
        }

        public async Task<OrderDTO> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderRequest = _mapper.Map<OrderCreationRequest>(request.orderCreationDTO);
            var order = await Protos.Order.CreateOrderAsync(orderRequest);

            var orderItemRequests = _mapper.Map<IList<OrderItemCreationRequest>>(request.orderCreationDTO!.Items);

            for (int i = 0; i < orderItemRequests.Count(); i++)
            {
                orderItemRequests[i].OrderId = order.OrderId;
                await Protos.OrderItem.CreateOrderItemAsync(orderItemRequests[i]);
            }

            return _mapper.Map<OrderDTO>(order);
        }
    }

}
