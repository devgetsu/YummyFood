using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyFood.Application.UseCases.OrderItems.Commands;
using YummyFood.Application.UseCases.OrderItems.Queries;

namespace YummyFood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderItem(CreateOrderItemCommand command, CancellationToken cancellationToken)
        {
            var orderItemId = await _mediator.Send(command, cancellationToken);
            return Ok(orderItemId);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderItem(UpdateOrderItemCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(int id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteOrderItemCommand { OrderItemId = id }, cancellationToken);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderItemById(int id, CancellationToken cancellationToken)
        {
            var orderItem = await _mediator.Send(new GetOrderItemByIdQuery { OrderItemId = id }, cancellationToken);
            return Ok(orderItem);
        }
    }
}
