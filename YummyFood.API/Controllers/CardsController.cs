using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using YummyFood.Application.UseCases.Cards.Commands;
using YummyFood.Application.UseCases.Cards.Queries;

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
        public async Task<IActionResult> DeleteCardAsync(DeleteCardCommand model, CancellationToken cancellationToken)
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

        [HttpPut]
        public async Task<IActionResult> UpdateCardAsync(UpdateCardCommand model, CancellationToken cancellationToken)
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

        [HttpGet]
        public async Task<IActionResult> GetAllCardsAsync(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(new GetAllCardsQuery(), cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCardByIdAsync(GetCardByIdQuery model, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(model.Id, cancellationToken);

            return Ok(result);
        }

        [HttpGet("Number")]
        public async Task<IActionResult> GetCardByNumberAsync(GetCardByNumberQuery model, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(model.Number, cancellationToken);

            return Ok(result);
        }
    }
}
