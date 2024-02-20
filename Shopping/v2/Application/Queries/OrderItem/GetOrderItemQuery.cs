using AutoMapper;
using MediatR;
using Shopping.API.Dto;
using Shopping.API.Protos.Manager;

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
        private readonly IProtosManager Protos;

        public GetOrderItemHandler(IMapper mapper, IProtosManager protos)
        {
            _mapper = mapper;
            Protos = protos;
        }

        public async Task<OrderItemDTO> Handle(GetOrderItemQuery request, CancellationToken cancellationToken)
        {
            var itemRequest = new GetItemRequest()
            {
                OrderId = request.oid.ToString(),
                ProductId = request.pid.ToString()
            };

            var item = await Protos.OrderItem.GetItemAsync(itemRequest);
            return _mapper.Map<OrderItemDTO>(item);
        }
    }

}
