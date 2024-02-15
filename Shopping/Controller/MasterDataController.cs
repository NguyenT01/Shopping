using Microsoft.AspNetCore.Mvc;
using Shopping.API.Dto;
using Shopping.API.Services.Interfaces;

namespace Shopping.API.Controller;

[Route("customer")]
[ApiController]
public class MasterDataController : ControllerBase
{
    private readonly IServiceManager _service;
    public MasterDataController(IServiceManager _service)
    {
        this._service = _service;
    }

    [HttpGet]

    public async Task<IActionResult> GetCustomerList()
    {
        var results = await _service.MasterDataService.GetCustomerList();
        return Ok(results);
    }

    [HttpGet("{cid:guid}")]
    public async Task<IActionResult> GetCustomerById(Guid cid)
    {
        var results = await _service.MasterDataService.GetCustomerById(cid);
        return Ok(results);
    }

    [HttpDelete("{cid:guid}")]
    public async Task<IActionResult> DeleteCustomer(Guid cid)
    {
        await _service.MasterDataService.DeleteCustomer(cid);
        return Ok();
    }


    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CustomerCreationDTO customerDTO)
    {
        var results = await _service.MasterDataService.CreateCustomer(customerDTO);
        return Ok(results);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCustomer([FromBody] CustomerUpdateDTO customerDTO)
    {
        await _service.MasterDataService.UpdateCustomer(customerDTO);
        return Ok();
    }

}
