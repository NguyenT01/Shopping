using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shopping.API.Dto;
using Shopping.API.v2.Application.Commands.Order;
using Shopping.API.v2.Application.Queries.Order;

namespace Shopping.API.v2.Controller
{
    [Route("v2/order")]
    [ApiController]
    public class OrderControllerV2 : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderControllerV2(IMediator mediator) { _mediator = mediator; }

        [HttpGet("{oid:guid}")]
        public async Task<IActionResult> GetOrder(Guid oid)
        {
            var order = await _mediator.Send(new GetOrderQuery()
            {
                oid = oid
            });
            return Ok(order);
        }

        [HttpGet("{cid:guid}/list")]
        public async Task<IActionResult> GetOrderList(Guid cid)
        {
            var orders = await _mediator.Send(new GetOrderListQuery()
            {
                cusId = cid
            });
            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreationDTO orderDTO)
        {
            var order = await _mediator.Send(new CreateOrderCommand()
            {
                orderCreationDTO = orderDTO
            });
            return Ok(order);
        }

        [HttpDelete("{oid:guid}")]
        public async Task<IActionResult> DeleteOrder(Guid oid)
        {
            await _mediator.Send(new DeleteOrderCommand()
            {
                oid = oid
            });
            return Ok();
        }


    }

}
