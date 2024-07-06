using MediatR;
using Microsoft.AspNetCore.Mvc;
using YummyFood.Application.UseCases.Products.Commands;
using YummyFood.Application.UseCases.Products.Queries;

namespace YummyFood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id, CancellationToken cancellationToken)
        {
            var command = new DeleteProductCommand { Id = id };

            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByIdAsync(long id, CancellationToken cancellationToken)
        {
            var query = new GetProductByIdQuery() { Id = id };
            var result = await _mediator.Send(query, cancellationToken);

            return Ok(result);
        }
    }
}
