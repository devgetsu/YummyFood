using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyFood.Application.UseCases.Promo.Commands;
using YummyFood.Application.UseCases.Promo.Queries;
using YummyFood.Domain.Entities.DTOs;
using YummyFood.Domain.Entities;
using YummyFood.Application.UseCases.SpecialOffer.Commands;
using YummyFood.Application.UseCases.SpecialOffer.Queries;
using System.Threading;

namespace YummyFood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOffersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SpecialOffersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffers(CreateSpecialOfferCommand command, CancellationToken cancellationToken)
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
        public async Task<IActionResult> GetAllSpecialOffers(CancellationToken cancellationToken)

        {
            try
            {
                var result = await _mediator.Send(new GetAllSpecialOfferCommandQuery(), cancellationToken);

                return Ok(result);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSpecialOffers(UpdateSpecialOfferCommand command,CancellationToken cancellationToken)
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
        [HttpDelete]
        public async Task<IActionResult> DeleteSpecialOffers(int id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(new DeleteSpecialOfferCommand() { Id = id }, cancellationToken);

                return Ok(result);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
