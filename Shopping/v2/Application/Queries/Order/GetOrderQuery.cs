using AutoMapper;
using MediatR;
using Shopping.API.Dto;

namespace Shopping.API.v2.Application.Queries.Order
{
    public class GetOrderQuery : IRequest<OrderDTO>
    {
        public Guid oid;
    }

    public class GetOrderHandler : IRequestHandler<GetOrderQuery, OrderDTO>
    {
        private readonly IMapper _mapper;
        private readonly OrderProto.OrderProtoClient orderProto;

        public GetOrderHandler(IMapper mapper, OrderProto.OrderProtoClient orderProto)
        {
            _mapper = mapper;
            this.orderProto = orderProto;
        }

        public async Task<OrderDTO> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var orderIDRequest = new OrderIdRequest()
            {
                OrderId = request.oid.ToString()
            };
            var order = await orderProto.GetOrderAsync(orderIDRequest);
            var orderDTO = _mapper.Map<OrderDTO>(order);
            return orderDTO;
        }
    }

}
