using AutoMapper;
using Shopping.API.Dto;
using Shopping.API.Protos.Manager;
using Shopping.API.Services.Interfaces;

namespace Shopping.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IProtosManager Protos;

        public OrderService(IMapper mapper, IProtosManager protos)
        {
            _mapper = mapper;
            Protos = protos;
        }

        public async Task<OrderDTO> CreateOrder(OrderCreationDTO orderCreationDTO)
        {
            var orderRequest = _mapper.Map<OrderCreationRequest>(orderCreationDTO);
            var order = await Protos.Order.CreateOrderAsync(orderRequest);

            var orderItemRequests = _mapper.Map<IList<OrderItemCreationRequest>>(orderCreationDTO.Items);

            for (int i = 0; i < orderItemRequests.Count(); i++)
            {
                orderItemRequests[i].OrderId = order.OrderId;
                await Protos.OrderItem.CreateOrderItemAsync(orderItemRequests[i]);
            }

            return _mapper.Map<OrderDTO>(order);
        }

        public async Task DeleteOrder(Guid oid)
        {
            var orderItemRequest = new OrderItemIdRequest()
            {
                OrderId = oid.ToString()
            };
            var orderItems = await Protos.OrderItem.GetItemsFromOrderAsync(orderItemRequest); ;

            if (orderItems.Items.Count > 0)
            {
                foreach (var item in orderItems.Items)
                {
                    var itemDeleteRequest = _mapper.Map<OrderItemDeletionRequest>(item);
                    await Protos.OrderItem.DeleteOrderItemAsync(itemDeleteRequest);
                }
            }

            await Protos.Order.DeleteOrderAsync(_mapper.Map<OrderIdRequest>(orderItemRequest));

        }

        public async Task<OrderDTO> GetOrder(Guid oid)
        {
            var orderIDRequest = new OrderIdRequest()
            {
                OrderId = oid.ToString()
            };
            var order = await Protos.Order.GetOrderAsync(orderIDRequest);
            var orderDTO = _mapper.Map<OrderDTO>(order);
            return orderDTO;
        }

        public async Task<IEnumerable<OrderDTO>> GetOrderList(Guid cusId)
        {
            var customerIDRequest = new OrderCustomerIdRequest()
            {
                CustomerId = cusId.ToString()
            };
            var orders = await Protos.Order.GetOrdersAsync(customerIDRequest);
            var ordersDTO = _mapper.Map<IEnumerable<OrderDTO>>(orders.Orders);
            return ordersDTO;
        }

        //-- PRIVATE FUNCTIONS

    }
}
