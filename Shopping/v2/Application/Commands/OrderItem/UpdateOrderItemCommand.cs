using AutoMapper;
using MediatR;
using Shopping.API.Dto;

namespace Shopping.API.v2.Application.Commands.OrderItem
{
    public class UpdateOrderItemCommand : IRequest<Unit>
    {
        public Guid oid;
        public OrderItemUpdateDTO? orderItemUpdateDTO;
    }

    public class UpdateOrderItemHandler : IRequestHandler<UpdateOrderItemCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly OrderItemProto.OrderItemProtoClient orderItemProto;
        public UpdateOrderItemHandler(IMapper mapper, OrderItemProto.OrderItemProtoClient orderItemProto)
        {
            _mapper = mapper;
            this.orderItemProto = orderItemProto;
        }

        public async Task<Unit> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<OrderItemUpdateRequest>(request.orderItemUpdateDTO);
            item.OrderId = request.oid.ToString();

            await orderItemProto.UpdateOrderItemAsync(item);
            return Unit.Value;
        }
    }

}
