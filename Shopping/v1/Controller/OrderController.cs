using Microsoft.AspNetCore.Mvc;
using Shopping.API.Dto;
using Shopping.API.v1.Services.Interfaces;

namespace Shopping.API.v1.Controller
{
    [Route("order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IServiceManager _services;

        public OrderController(IServiceManager services)
        {
            _services = services;
        }

        [HttpGet("{oid:guid}")]
        public async Task<IActionResult> GetOrder(Guid oid)
        {
            var order = await _services.OrderService.GetOrder(oid);
            return Ok(order);
        }

        [HttpGet("{cid:guid}/list")]
        public async Task<IActionResult> GetOrderList(Guid cid)
        {
            var orders = await _services.OrderService.GetOrderList(cid);
            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreationDTO orderDTO)
        {
            var order = await _services.OrderService.CreateOrder(orderDTO);
            return Ok(order);
        }

        [HttpDelete("{oid:guid}")]
        public async Task<IActionResult> DeleteOrder(Guid oid)
        {
            await _services.OrderService.DeleteOrder(oid);
            return Ok();
        }
    }
}
