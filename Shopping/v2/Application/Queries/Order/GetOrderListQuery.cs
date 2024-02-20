using AutoMapper;
using MediatR;
using Shopping.API.Dto;
using Shopping.API.Protos.Manager;

namespace Shopping.API.v2.Application.Queries.Order
{
    public class GetOrderListQuery : IRequest<IEnumerable<OrderDTO>>
    {
        public Guid cusId;
    }

    public class GetOrderListHandler : IRequestHandler<GetOrderListQuery, IEnumerable<OrderDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IProtosManager Protos;

        public GetOrderListHandler(IMapper mapper, IProtosManager Protos)
        {
            _mapper = mapper;
            this.Protos = Protos;
        }

        public async Task<IEnumerable<OrderDTO>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var customerIDRequest = new OrderCustomerIdRequest()
            {
                CustomerId = request.cusId.ToString()
            };
            var orders = await Protos.Order.GetOrdersAsync(customerIDRequest);
            var ordersDTO = _mapper.Map<IEnumerable<OrderDTO>>(orders.Orders);
            return ordersDTO;
        }
    }
}
