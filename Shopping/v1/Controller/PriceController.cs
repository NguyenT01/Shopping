using Microsoft.AspNetCore.Mvc;
using Shopping.API.Dto;
using Shopping.API.v1.Services.Interfaces;

namespace Shopping.API.v1.Controller
{
    [Route("price")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly IServiceManager _services;

        public PriceController(IServiceManager services)
        {
            _services = services;
        }

        [HttpGet("{pid:guid}")]
        public async Task<IActionResult> GetPrice(Guid pid)
        {
            var price = await _services.PriceService.GetPrice(pid);
            return Ok(price);
        }

        [HttpGet("product/{proId:guid}")]
        public async Task<IActionResult> GetPricesByProduct(Guid proId)
        {
            var prices = await _services.PriceService.GetAllPrices(proId);
            return Ok(prices);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePrice([FromBody] PriceCreationDTO priceDTO)
        {
            var price = await _services.PriceService.CreatePrice(priceDTO);
            return Ok(price);
        }

        [HttpDelete("{pid:guid}")]
        public async Task<IActionResult> DeletePrice(Guid pid)
        {
            await _services.PriceService.DeletePrice(pid);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePrice([FromBody] PriceUpdateDTO priceUpdateDTO)
        {
            await _services.PriceService.UpdatePrice(priceUpdateDTO);
            return Ok();
        }
    }
}
