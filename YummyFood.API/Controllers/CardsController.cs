using MediatR;
using Microsoft.AspNetCore.Mvc;
using YummyFood.Application.UseCases.Cards.Commands;

namespace YummyFood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CardsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCardAsync(CreateCardCommand model, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(model, cancellationToken);

                return Ok(result);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCardAsync(long id, CancellationToken cancellationToken)
        {
            try
            {
                var model = new DeleteCardCommand()
                {
                    Id = id
                };

                var result = await _mediator.Send(model, cancellationToken);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCardAsync(UpdateCardCommand command, CancellationToken cancellationToken)
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
