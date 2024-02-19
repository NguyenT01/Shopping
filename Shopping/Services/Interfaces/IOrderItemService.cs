using Shopping.API.Dto;

namespace Shopping.API.Services.Interfaces
{
    public interface IOrderItemService
    {
        Task<OrderItemDTO> GetOrderItem(Guid oid, Guid pid);
        Task<IEnumerable<OrderItemDTO>> GetOrderItemList(Guid oid);
        Task<OrderItemDTO> CreateOrderItem(Guid oid, OrderItemCreationWithoutOrderId orderItemCreationWithoutOrderId);
        Task DeleteOrderItem(Guid oid, Guid pid);
        Task UpdateOrderItem(Guid oid, OrderItemUpdateDTO orderItemUpdateDTO);
    }
}
