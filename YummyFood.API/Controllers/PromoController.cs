using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyFood.Application.UseCases.Promo.Commands;
using YummyFood.Application.UseCases.Promo.Queries;
using YummyFood.Domain.Entities;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PromoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ResponseModel> CreateAnswer(CreatePromoCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpGet]
        public async Task<List<PromoModel>> GetAllAnswer()
        {
            return await _mediator.Send(new GetAllPromoCommandQuery());
        }
       
        [HttpPut]
        public async Task<ResponseModel> UpdateAnswer(UpdatePromoCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpDelete]
        public async Task<ResponseModel> DeleteAnswer(int id)
        {
            return await _mediator.Send(new DeletePromoCommand() { Id = id });
        }
    }
}
