using AutoMapper;
using MediatR;
using Shopping.API.Dto;
using Shopping.API.Protos.Manager;

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
        private readonly IProtosManager Protos;

        public CreateOrderItemHandler(IMapper mapper, IProtosManager protos)
        {
            _mapper = mapper;
            Protos = protos;
        }

        public async Task<OrderItemDTO> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<OrderItemCreationRequest>(request.orderItemCreationWithoutOrderId);
            item.OrderId = request.oid.ToString();

            var itemResponse = await Protos.OrderItem.CreateOrderItemAsync(item);
            return _mapper.Map<OrderItemDTO>(itemResponse);
        }
    }

}
