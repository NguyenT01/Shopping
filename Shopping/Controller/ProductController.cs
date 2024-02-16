using Microsoft.AspNetCore.Mvc;
using Shopping.API.Dto;
using Shopping.API.Services.Interfaces;

namespace Shopping.API.Controller
{
    [Route("product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IServiceManager _services;

        public ProductController(IServiceManager services)
        {
            _services = services;
        }

        [HttpGet("{pid:guid}")]
        public async Task<IActionResult> GetProductById(Guid pid)
        {
            var product = await _services.ProductService.GetProductById(pid);
            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductList()
        {
            var products = await _services.ProductService.GetProductList();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewProduct([FromBody] ProductCreationDTO productCreationDTO)
        {
            var product = await _services.ProductService.AddProduct(productCreationDTO);
            return Ok(product);
        }

        [HttpDelete("{pid:guid}")]
        public async Task<IActionResult> DeleteProduct(Guid pid)
        {
            await _services.ProductService.DeleteProduct(pid);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductUpdateDTO product)
        {
            await _services.ProductService.UpdateProduct(product);
            return Ok();
        }
    }
}
