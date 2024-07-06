using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyFood.Application.UseCases.Orders.Commands;
using YummyFood.Application.UseCases.Orders.Queries;

namespace YummyFood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id, CancellationToken cancellationToken)
        {
            var command = new DeleteOrderCommand() { Id = id };
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateAsync(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }

        [HttpPatch("AddItemToOrder")]
        public async Task<IActionResult> UpdateOrderItemsAsync(AddItemsToOrderCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetOrderByUserIdAsync(long userId, CancellationToken cancellationToken)
        {
            var query = new GetOrderByUserIdQuery() { UserId = userId };
            var result = await _mediator.Send(query, cancellationToken);

            return Ok(result);
        }
    }
}
