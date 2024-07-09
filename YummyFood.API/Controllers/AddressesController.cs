using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyFood.Application.UseCases.Addresses.Commands;
using YummyFood.Application.UseCases.Addresses.Queries;

namespace YummyFood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddressAsync(CreateAddressCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddressAsync(long id, CancellationToken cancellationToken)
        {
            var command = new DeleteAddressCommand { Id = id };
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAddressesAsync([FromQuery] int index, [FromQuery] int size, CancellationToken cancellationToken)
        {
            var query = new GetAllAddressesQuery()
            {
                PageIndex = index,
                PageSize = size
            };
            var result = await _mediator.Send(query, cancellationToken);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddressAsync(UpdateAddressCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }

        [HttpPost("FindTheClosestAddress")]
        public async Task<IActionResult> FindTheClosestAddressAsync(FindTheClosestAddressCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }
    }
}
