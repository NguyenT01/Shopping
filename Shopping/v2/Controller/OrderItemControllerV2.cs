using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shopping.API.Dto;
using Shopping.API.v2.Application.Commands.OrderItem;
using Shopping.API.v2.Application.Queries.OrderItem;

namespace Shopping.API.v2.Controller
{
    [Route("v2/order/{oid:guid}/item")]
    [ApiController]
    public class OrderItemControllerV2 : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderItemControllerV2(IMediator mediator) { _mediator = mediator; }

        [HttpGet("{pid:guid}")]
        public async Task<IActionResult> GetItem(Guid oid, Guid pid)
        {
            var item = await _mediator.Send(new GetOrderItemQuery()
            {
                oid = oid,
                pid = pid
            });
            return Ok(item);
        }

        [HttpGet]
        public async Task<IActionResult> GetItemsFromOrder(Guid oid)
        {
            var items = await _mediator.Send(new GetItemsFromOrderQuery()
            {
                oid = oid
            });
            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem(Guid oid, [FromBody] OrderItemCreationWithoutOrderId orderItemCreationWithoutOrderId)
        {
            var item = await _mediator.Send(new CreateOrderItemCommand()
            {
                oid = oid,
                orderItemCreationWithoutOrderId = orderItemCreationWithoutOrderId
            });
            return Ok(item);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateItem(Guid oid, [FromBody] OrderItemUpdateDTO orderItemUpdateDTO)
        {
            await _mediator.Send(new UpdateOrderItemCommand()
            {
                oid = oid,
                orderItemUpdateDTO = orderItemUpdateDTO
            });
            return Ok();
        }

        [HttpDelete("{pid:guid}")]
        public async Task<IActionResult> DeleteItem(Guid oid, Guid pid)
        {
            await _mediator.Send(new DeleteOrderItemCommand()
            {
                oid = oid,
                pid = pid
            });
            return Ok();
        }


    }
}
