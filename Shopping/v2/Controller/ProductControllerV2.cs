using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shopping.API.Dto;
using Shopping.API.v2.Application.Commands.Product;
using Shopping.API.v2.Application.Queries.Product;

namespace Shopping.API.v2.Controller
{
    [Route("v2/product")]
    [ApiController]
    public class ProductControllerV2 : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductControllerV2(IMediator mediator) { _mediator = mediator; }

        [HttpGet("{pid:guid}")]
        public async Task<IActionResult> GetProductById(Guid pid)
        {
            var product = await _mediator.Send(new GetProductByIdQuery()
            {
                pid = pid
            });

            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductList([FromBody] ProductCreationDTO productCreationDTO)
        {
            var product = await _mediator.Send(new GetProductListQuery());
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewProduct([FromBody] ProductCreationDTO productCreationDto)
        {
            var product = await _mediator.Send(new AddProductCommand()
            {
                productCreationDTO = productCreationDto
            });
            return Ok(product);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductUpdateDTO product)
        {
            await _mediator.Send(new UpdateProductCommand() { productDTO = product });
            return Ok();
        }

        [HttpDelete("{pid:guid}")]
        public async Task<IActionResult> DeleteProduct(Guid pid)
        {
            await _mediator.Send(new DeleteProductCommand() { pid = pid });
            return Ok();
        }


    }
}
