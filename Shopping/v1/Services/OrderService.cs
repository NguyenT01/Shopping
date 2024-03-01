using AutoMapper;
using Shopping.API.Dto;
using Shopping.API.Protos.Manager;
using Shopping.API.v1.Services.Interfaces;

namespace Shopping.API.v1.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly OrderProto.OrderProtoClient orderProto;
        private readonly OrderItemProto.OrderItemProtoClient orderItemProto;

        public OrderService(IMapper mapper, OrderProto.OrderProtoClient orderProto, OrderItemProto.OrderItemProtoClient orderItemProto)
        {
            _mapper = mapper;
            this.orderProto = orderProto;
            this.orderItemProto = orderItemProto;
        }

        public async Task<OrderDTO> CreateOrder(OrderCreationDTO orderCreationDTO)
        {
            var orderRequest = _mapper.Map<OrderCreationRequest>(orderCreationDTO);
            var order = await orderProto.CreateOrderAsync(orderRequest);

            var orderItemRequests = _mapper.Map<IList<OrderItemCreationRequest>>(orderCreationDTO.Items);

            for (int i = 0; i < orderItemRequests.Count(); i++)
            {
                orderItemRequests[i].OrderId = order.OrderId;
                await orderItemProto.CreateOrderItemAsync(orderItemRequests[i]);
            }

            return _mapper.Map<OrderDTO>(order);
        }

        public async Task DeleteOrder(Guid oid)
        {
            var orderItemRequest = new OrderItemIdRequest()
            {
                OrderId = oid.ToString()
            };
            var orderItems = await orderItemProto.GetItemsFromOrderAsync(orderItemRequest); ;

            if (orderItems.Items.Count > 0)
            {
                foreach (var item in orderItems.Items)
                {
                    var itemDeleteRequest = _mapper.Map<OrderItemDeletionRequest>(item);
                    await orderItemProto.DeleteOrderItemAsync(itemDeleteRequest);
                }
            }

            await orderProto.DeleteOrderAsync(_mapper.Map<OrderIdRequest>(orderItemRequest));

        }

        public async Task<OrderDTO> GetOrder(Guid oid)
        {
            var orderIDRequest = new OrderIdRequest()
            {
                OrderId = oid.ToString()
            };
            var order = await orderProto.GetOrderAsync(orderIDRequest);
            var orderDTO = _mapper.Map<OrderDTO>(order);
            return orderDTO;
        }

        public async Task<IEnumerable<OrderDTO>> GetOrderList(Guid cusId)
        {
            var customerIDRequest = new OrderCustomerIdRequest()
            {
                CustomerId = cusId.ToString()
            };
            var orders = await orderProto.GetOrdersAsync(customerIDRequest);
            var ordersDTO = _mapper.Map<IEnumerable<OrderDTO>>(orders.Orders);
            return ordersDTO;
        }

        //-- PRIVATE FUNCTIONS

    }
}
