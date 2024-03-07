using AutoMapper;
using Shopping.API.Dto;
using Shopping.API.v1.Services.Interfaces;

namespace Shopping.API.v1.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IMapper _mapper;
        private readonly OrderItemProto.OrderItemProtoClient orderItemProto;

        public OrderItemService(IMapper mapper, OrderItemProto.OrderItemProtoClient orderItemProto)
        {
            _mapper = mapper;
            this.orderItemProto = orderItemProto;
        }

        public async Task<OrderItemDTO> CreateOrderItem(Guid oid, OrderItemCreationWithoutOrderId orderItemCreationWithoutOrderId)
        {
            var item = _mapper.Map<OrderItemCreationRequest>(orderItemCreationWithoutOrderId);
            item.OrderId = oid.ToString();

            var itemResponse = await orderItemProto.CreateOrderItemAsync(item);
            return _mapper.Map<OrderItemDTO>(itemResponse);
        }

        public async Task DeleteOrderItem(Guid oid, Guid pid)
        {
            var itemRequest = new OrderItemDeletionRequest()
            {
                OrderId = oid.ToString(),
                ProductId = pid.ToString()
            };

            await orderItemProto.DeleteOrderItemAsync(itemRequest);
        }

        public async Task<OrderItemDTO> GetOrderItem(Guid oid, Guid pid)
        {
            var itemRequest = new GetItemRequest()
            {
                OrderId = oid.ToString(),
                ProductId = pid.ToString()
            };

            var item = await orderItemProto.GetItemAsync(itemRequest);
            return _mapper.Map<OrderItemDTO>(item);
        }

        public async Task<IEnumerable<OrderItemDTO>> GetOrderItemList(Guid oid)
        {
            var orderRequest = new OrderItemIdRequest()
            {
                OrderId = oid.ToString()
            };

            var items = await orderItemProto.GetItemsFromOrderAsync(orderRequest);
            return _mapper.Map<IEnumerable<OrderItemDTO>>(items.Items);
        }

        public async Task UpdateOrderItem(Guid oid, OrderItemUpdateDTO orderItemUpdateDTO)
        {
            var item = _mapper.Map<OrderItemUpdateRequest>(orderItemUpdateDTO);
            item.OrderId = oid.ToString();

            await orderItemProto.UpdateOrderItemAsync(item);
        }
    }
}
