using AutoMapper;
using Shopping.API.Dto;
using Shopping.API.Protos.Manager;
using Shopping.API.Services.Interfaces;

namespace Shopping.API.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IMapper _mapper;
        private readonly IProtosManager Protos;

        public OrderItemService(IMapper mapper, IProtosManager protos)
        {
            _mapper = mapper;
            Protos = protos;
        }

        public async Task<OrderItemDTO> CreateOrderItem(Guid oid, OrderItemCreationWithoutOrderId orderItemCreationWithoutOrderId)
        {
            var item = _mapper.Map<OrderItemCreationRequest>(orderItemCreationWithoutOrderId);
            item.OrderId = oid.ToString();

            var itemResponse = await Protos.OrderItem.CreateOrderItemAsync(item);
            return _mapper.Map<OrderItemDTO>(itemResponse);
        }

        public async Task DeleteOrderItem(Guid oid, Guid pid)
        {
            var itemRequest = new OrderItemDeletionRequest()
            {
                OrderId = oid.ToString(),
                ProductId = pid.ToString()
            };

            await Protos.OrderItem.DeleteOrderItemAsync(itemRequest);
        }

        public async Task<OrderItemDTO> GetOrderItem(Guid oid, Guid pid)
        {
            var itemRequest = new GetItemRequest()
            {
                OrderId = oid.ToString(),
                ProductId = pid.ToString()
            };

            var item = await Protos.OrderItem.GetItemAsync(itemRequest);
            return _mapper.Map<OrderItemDTO>(item);
        }

        public async Task<IEnumerable<OrderItemDTO>> GetOrderItemList(Guid oid)
        {
            var orderRequest = new OrderItemIdRequest()
            {
                OrderId = oid.ToString()
            };

            var items = await Protos.OrderItem.GetItemsFromOrderAsync(orderRequest);
            return _mapper.Map<IEnumerable<OrderItemDTO>>(items.Items);
        }

        public async Task UpdateOrderItem(Guid oid, OrderItemUpdateDTO orderItemUpdateDTO)
        {
            var item = _mapper.Map<OrderItemUpdateRequest>(orderItemUpdateDTO);
            item.OrderId = oid.ToString();

            await Protos.OrderItem.UpdateOrderItemAsync(item);
        }
    }
}
