using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.Admins.Command;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.Application.UseCases.Admins.Handlers.CommandHandlers
{
    public class UpdateAdminCommandHandler : IRequestHandler<UpdateAdminCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public UpdateAdminCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var admin = await _context.Admins.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                if (admin == null)
                {
                    return new ResponseModel()
                    {
                        Message = "Admin not found",
                        StatusCode = 404,
                        IsSuccess = false,
                    };
                }

                admin.Password = request.Password;
                admin.PhoneNumber = request.PhoneNumber;
                admin.UserName = request.UserName;

                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel()
                {
                    IsSuccess = true,
                    Message = "Successfully updated",
                    StatusCode = 200
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    Message = $"There is an Issue in Update Admin Service || {ex.Message}",
                    StatusCode = 404,
                    IsSuccess = false,
                };
            }
        }
    }
}
