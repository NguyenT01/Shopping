using AutoMapper;
using MediatR;
using Shopping.API.Dto;
using Shopping.API.Protos.Manager;

namespace Shopping.API.v2.Application.Queries.Order
{
    public class GetOrderQuery : IRequest<OrderDTO>
    {
        public Guid oid;
    }

    public class GetOrderHandler : IRequestHandler<GetOrderQuery, OrderDTO>
    {
        private readonly IMapper _mapper;
        private readonly IProtosManager Protos;

        public GetOrderHandler(IMapper mapper, IProtosManager protos)
        {
            _mapper = mapper;
            Protos = protos;
        }

        public async Task<OrderDTO> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var orderIDRequest = new OrderIdRequest()
            {
                OrderId = request.oid.ToString()
            };
            var order = await Protos.Order.GetOrderAsync(orderIDRequest);
            var orderDTO = _mapper.Map<OrderDTO>(order);
            return orderDTO;
        }
    }

}
