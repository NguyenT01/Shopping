using AutoMapper;
using MediatR;
using Shopping.API.Dto;

namespace Shopping.API.v2.Application.Queries.Order
{
    public class GetOrderListQuery : IRequest<IEnumerable<OrderDTO>>
    {
        public Guid cusId;
    }

    public class GetOrderListHandler : IRequestHandler<GetOrderListQuery, IEnumerable<OrderDTO>>
    {
        private readonly IMapper _mapper;
        private readonly OrderProto.OrderProtoClient orderProto;

        public GetOrderListHandler(IMapper mapper, OrderProto.OrderProtoClient orderProto)
        {
            _mapper = mapper;
            this.orderProto = orderProto;
        }

        public async Task<IEnumerable<OrderDTO>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var customerIDRequest = new OrderCustomerIdRequest()
            {
                CustomerId = request.cusId.ToString()
            };
            var orders = await orderProto.GetOrdersAsync(customerIDRequest);
            var ordersDTO = _mapper.Map<IEnumerable<OrderDTO>>(orders.Orders);
            return ordersDTO;
        }
    }
}
