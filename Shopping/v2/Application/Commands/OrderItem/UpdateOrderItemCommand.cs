using AutoMapper;
using MediatR;
using Shopping.API.Dto;
using Shopping.API.Protos.Manager;

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
        private readonly IProtosManager Protos;

        public UpdateOrderItemHandler(IMapper mapper, IProtosManager protos)
        {
            _mapper = mapper;
            Protos = protos;
        }

        public async Task<Unit> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<OrderItemUpdateRequest>(request.orderItemUpdateDTO);
            item.OrderId = request.oid.ToString();

            await Protos.OrderItem.UpdateOrderItemAsync(item);
            return Unit.Value;
        }
    }

}
