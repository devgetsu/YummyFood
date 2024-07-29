using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using YummyFood.Application.Abstractions.AuthServices;
using YummyFood.Application.UseCases.Admins.Command;
using YummyFood.Application.UseCases.Admins.Query;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAuthService _authService;

        public AdminsController(IMediator mediator, IAuthService authService)
        {
            _mediator = mediator;
            _authService = authService;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> CreateAdmin(CreateAdminCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAdmin(UpdateAdminCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(long id, CancellationToken cancellationToken)
        {
            var command = new DeleteAdminCommand { Id = id };
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdminById(long id, CancellationToken cancellationToken)
        {
            var query = new GetAdminByIdQuery { Id = id };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdmin(CancellationToken cancellationToken)
        {
            var query = new GetAllAdminsQuery { };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> AdminLogin(AdminLoginDTO model, CancellationToken cancellation)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var query = new GetAdminByLogin()
            {
                PhoneNumber = model.PhoneNumber,
            };

            var admin = await _mediator.Send(query, cancellation);

            var response = _authService.GenerateTokenAdmin(admin);
         
            return Ok(response);
        }
    }
}
