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
    public class DeleteAdminCommandHandler : IRequestHandler<DeleteAdminCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public DeleteAdminCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
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

                _context.Admins.Remove(admin);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel()
                {
                    IsSuccess = true,
                    Message = "Successfully deleted",
                    StatusCode = 200
                };
            }
            catch (Exception ex)
            {

                return new ResponseModel()
                {
                    Message = $"There is an Issue in Delete Admin Service || {ex.Message}",
                    StatusCode = 404,
                    IsSuccess = false,
                };
            }
        }
    }
}
