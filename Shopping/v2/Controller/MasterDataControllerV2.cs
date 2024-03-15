using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopping.API.Dto;
using Shopping.API.v2.Application.Commands.MasterData;
using Shopping.API.v2.Application.Queries.MasterData;

namespace Shopping.API.v2.Controller
{
    [Route("v2/customer")]
    [Authorize]
    [ApiController]
    public class MasterDataControllerV2 : ControllerBase
    {
        private readonly IMediator _mediator;

        public MasterDataControllerV2(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{cid:guid}")]
        public async Task<IActionResult> GetCustomerById(Guid cid)
        {
            var results = await _mediator.Send(new GetCustomerByIdQuery()
            {
                cid = cid
            });
            return Ok(results);
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerList()
        {
            var results = await _mediator.Send(new GetCustomerListQuery());
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerCreationDTO customerDTO)
        {
            var results = await _mediator.Send(new CreateCustomerCommand()
            {
                customerDTO = customerDTO
            });
            return Ok(results);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerUpdateDTO customerDTO)
        {
            await _mediator.Send(new UpdateCustomerCommand() { CustomerUpdateDTO = customerDTO });
            return Ok();
        }

        [HttpDelete("{cid:guid}")]
        public async Task<IActionResult> DeleteCustomer(Guid cid)
        {
            await _mediator.Send(new DeleteCustomerCommand() { cid = cid });
            return Ok();
        }

    }
}
