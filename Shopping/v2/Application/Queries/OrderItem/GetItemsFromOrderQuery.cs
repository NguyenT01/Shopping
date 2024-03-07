using AutoMapper;
using MediatR;
using Shopping.API.Dto;

namespace Shopping.API.v2.Application.Queries.OrderItem
{
    public record GetItemsFromOrderQuery : IRequest<IEnumerable<OrderItemDTO>>
    {
        public Guid oid;
    }

    public class GetItemsFromOrderHandler : IRequestHandler<GetItemsFromOrderQuery, IEnumerable<OrderItemDTO>>
    {
        private readonly IMapper _mapper;
        private readonly OrderItemProto.OrderItemProtoClient orderItemProto;

        public GetItemsFromOrderHandler(IMapper mapper, OrderItemProto.OrderItemProtoClient orderItemProto)
        {
            _mapper = mapper;
            this.orderItemProto = orderItemProto;
        }

        public async Task<IEnumerable<OrderItemDTO>> Handle(GetItemsFromOrderQuery request, CancellationToken cancellationToken)
        {
            var orderRequest = new OrderItemIdRequest()
            {
                OrderId = request.oid.ToString()
            };

            var items = await orderItemProto.GetItemsFromOrderAsync(orderRequest);
            return _mapper.Map<IEnumerable<OrderItemDTO>>(items.Items);
        }
    }

}
