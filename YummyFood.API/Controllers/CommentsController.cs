using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyFood.Application.UseCases.Comments.Commands;
using YummyFood.Application.UseCases.Comments.Queries;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(UpdateCommentCommand command, CancellationToken cancellationToken)
        {

            var response = await _mediator.Send(command, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(long id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new DeleteCommentCommand { Id = id }, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(long id, CancellationToken cancellationToken)
        {
            var comment = await _mediator.Send(new GetCommentByIdQuery { Id = id }, cancellationToken);
            return Ok(comment);
        }
    }

}
