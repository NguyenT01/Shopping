using AutoMapper;
using MediatR;
using Shopping.API.Dto;
using Shopping.API.Protos.Manager;

namespace Shopping.API.v2.Application.Queries.OrderItem
{
    public record GetItemsFromOrderQuery : IRequest<IEnumerable<OrderItemDTO>>
    {
        public Guid oid;
    }

    public class GetItemsFromOrderHandler : IRequestHandler<GetItemsFromOrderQuery, IEnumerable<OrderItemDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IProtosManager Protos;

        public GetItemsFromOrderHandler(IMapper mapper, IProtosManager protos)
        {
            _mapper = mapper;
            Protos = protos;
        }

        public async Task<IEnumerable<OrderItemDTO>> Handle(GetItemsFromOrderQuery request, CancellationToken cancellationToken)
        {
            var orderRequest = new OrderItemIdRequest()
            {
                OrderId = request.oid.ToString()
            };

            var items = await Protos.OrderItem.GetItemsFromOrderAsync(orderRequest);
            return _mapper.Map<IEnumerable<OrderItemDTO>>(items.Items);
        }
    }

}
