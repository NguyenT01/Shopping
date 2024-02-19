using Microsoft.AspNetCore.Mvc;
using Shopping.API.Dto;
using Shopping.API.Services.Interfaces;

namespace Shopping.API.Controller
{
    [Route("order/{oid:guid}/item")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IServiceManager _services;

        public OrderItemController(IServiceManager services) { _services = services; }

        [HttpGet("{pid:guid}")]
        public async Task<IActionResult> GetItem(Guid oid, Guid pid)
        {
            var item = await _services.OrderItemService.GetOrderItem(oid, pid);
            return Ok(item);
        }

        [HttpGet]
        public async Task<IActionResult> GetItemsFromOrder(Guid oid)
        {
            var items = await _services.OrderItemService.GetOrderItemList(oid);
            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem(Guid oid, [FromBody] OrderItemCreationWithoutOrderId orderItemCreationWithoutOrderId)
        {
            var item = await _services.OrderItemService.CreateOrderItem(oid, orderItemCreationWithoutOrderId);
            return Ok(item);
        }

        [HttpDelete("{pid:guid}")]
        public async Task<IActionResult> DeleteItem(Guid oid, Guid pid)
        {
            await _services.OrderItemService.DeleteOrderItem(oid, pid);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateItem(Guid oid, [FromBody] OrderItemUpdateDTO orderItemUpdateDTO)
        {
            await _services.OrderItemService.UpdateOrderItem(oid, orderItemUpdateDTO);
            return Ok();
        }
    }
}
