using MediatR;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.Admins.Command;
using YummyFood.Domain.Entities.Auth;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.Application.UseCases.Admins.Handlers.CommandHandlers
{
    public class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public CreateAdminCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var admin = new AdminApp()
                {
                    Role = request.Role,
                    Email = request.Email,
                    Password = request.Password,
                    PhoneNumber = request.PhoneNumber,
                    UserName = request.UserName,
                };

                await _context.Admins.AddAsync(admin, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);


                return new ResponseModel()
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Message = "Successfully Created"
                };
            }
            catch (Exception ex)
            {

                return new ResponseModel()
                {
                    Message = $"There is an Issue in Create Admin Service || {ex.Message}",
                    StatusCode = 404,
                    IsSuccess = false,
                };
            }
        }
    }
}
