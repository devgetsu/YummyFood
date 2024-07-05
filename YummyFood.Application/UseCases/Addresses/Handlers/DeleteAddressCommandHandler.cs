using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.Addresses.Commands;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.Application.UseCases.Addresses.Handlers
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public DeleteAddressCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var address = await _context.Addresses.FindAsync(request.Id, cancellationToken);

                if (address == null)
                {
                    return new ResponseModel()
                    {
                        IsSuccess = false,
                        Message = "Address not found",
                        StatusCode = 404
                    };
                }

                _context.Addresses.Remove(address);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel()
                {
                    IsSuccess = true,
                    Message = "Address deleted",
                    StatusCode = 200
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    StatusCode = 400
                };
            }
        }
    }
}
