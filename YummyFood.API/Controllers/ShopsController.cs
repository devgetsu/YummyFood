using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyFood.Application.UseCases.Shops.Commands;
using YummyFood.Application.UseCases.Shops.Queries;

namespace YummyFood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShopsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateShopAscyn([FromForm] CreateShopCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(command, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShopAsync(long id, CancellationToken cancellationToken)
        {
            try
            {
                var command = new DeleteShopCommand()
                {
                    Id = id
                };
                var result = await _mediator.Send(command, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateShopAsync(UpdateShopCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(command, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllShopsWithPaginationAsync([FromQuery] int index, [FromQuery] int size, CancellationToken cancellationToken)
        {
            try
            {
                var command = new GetAllShopsWithPaginationQuery()
                {
                    PageIndex = index,
                    PageSize = size
                };
                var result = await _mediator.Send(command, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
