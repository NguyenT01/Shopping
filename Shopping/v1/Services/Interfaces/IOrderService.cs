﻿using Shopping.API.Dto;

namespace Shopping.API.v1.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDTO> GetOrder(Guid oid);
        Task<IEnumerable<OrderDTO>> GetOrderList(Guid cusId);
        Task<OrderDTO> CreateOrder(OrderCreationDTO orderCreationDTO);
        Task DeleteOrder(Guid oid);
    }
}
