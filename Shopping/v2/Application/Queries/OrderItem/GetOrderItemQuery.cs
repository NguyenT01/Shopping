using AutoMapper;
using MediatR;
using Shopping.API.Dto;

namespace Shopping.API.v2.Application.Queries.OrderItem
{
    public class GetOrderItemQuery : IRequest<OrderItemDTO>
    {
        public Guid oid;
        public Guid pid;
    }

    public class GetOrderItemHandler : IRequestHandler<GetOrderItemQuery, OrderItemDTO>
    {
        private readonly IMapper _mapper;
        private readonly OrderItemProto.OrderItemProtoClient orderItemProto;

        public GetOrderItemHandler(IMapper mapper, OrderItemProto.OrderItemProtoClient orderItemProto)
        {
            _mapper = mapper;
            this.orderItemProto = orderItemProto;
        }

        public async Task<OrderItemDTO> Handle(GetOrderItemQuery request, CancellationToken cancellationToken)
        {
            var itemRequest = new GetItemRequest()
            {
                OrderId = request.oid.ToString(),
                ProductId = request.pid.ToString()
            };

            var item = await orderItemProto.GetItemAsync(itemRequest);
            return _mapper.Map<OrderItemDTO>(item);
        }
    }

}
