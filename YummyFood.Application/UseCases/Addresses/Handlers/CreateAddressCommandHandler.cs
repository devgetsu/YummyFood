using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.Addresses.Commands;
using YummyFood.Domain.Entities;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.Application.UseCases.Addresses.Handlers
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public CreateAddressCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var addressModel = new Address()
                {
                    Letitude = request.Letitude,
                    Longitude = request.Longitude,
                    Name = request.Name,
                };

                await _context.Addresses.AddAsync(addressModel, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel()
                {
                    IsSuccess = true,
                    Message = "Address Created",
                    StatusCode = 201
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
