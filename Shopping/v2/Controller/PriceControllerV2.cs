using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopping.API.Dto;
using Shopping.API.v2.Application.Commands.Price;
using Shopping.API.v2.Application.Queries.Price;

namespace Shopping.API.v2.Controller
{
    [Route("v2/price")]
    [Authorize]
    [ApiController]
    public class PriceControllerV2 : ControllerBase
    {
        private readonly IMediator _mediator;
        public PriceControllerV2(IMediator mediator) { _mediator = mediator; }

        [HttpGet("{pid:guid}")]
        public async Task<IActionResult> GetPrice(Guid pid)
        {
            var price = await _mediator.Send(new GetPriceQuery()
            {
                priceId = pid
            });
            return Ok(price);
        }

        [HttpGet("product/{proId:guid}")]
        public async Task<IActionResult> GetPricesByProduct(Guid proId)
        {
            var prices = await _mediator.Send(new GetPricesByProductQuery()
            {
                productId = proId
            });
            return Ok(prices);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePrice([FromBody] PriceCreationDTO priceDTO)
        {
            var price = await _mediator.Send(new CreatePriceCommand()
            {
                priceCreationDTO = priceDTO
            });
            return Ok(price);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePrice([FromBody] PriceUpdateDTO priceUpdateDTO)
        {
            await _mediator.Send(new UpdatePriceCommand()
            {
                priceDTO = priceUpdateDTO
            });
            return Ok();
        }

        [HttpDelete("{pid:guid}")]
        public async Task<IActionResult> DeletePrice(Guid pid)
        {
            await _mediator.Send(new DeletePriceCommand()
            {
                priceId = pid
            });
            return Ok();
        }


    }
}

