using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.Shops.Commands;
using YummyFood.Domain.Entities;
using YummyFood.Domain.Entities.DTOs;
using YummyFood.Domain.Exceptions;

namespace YummyFood.Application.UseCases.Shops.Handlers
{
    public class DeleteShopCommandHandler : IRequestHandler<DeleteShopCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public DeleteShopCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteShopCommand request, CancellationToken cancellationToken)
        {
            var shop = await _context.Shops.FindAsync(request.Id);

            if (shop is null)
            {
                return new ResponseModel()
                {
                    Message = "Not found",
                    IsSuccess = false,
                    StatusCode = 404
                };
            }

            _context.Shops.Remove(shop);

            try
            {
                File.Delete(shop.Photo);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete photo: {ex.Message}");
            }

            try
            {
                File.Delete(shop.PreviewPhoto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete preview photo: {ex.Message}");
            }

            await _context.SaveChangesAsync(cancellationToken);
            return new ResponseModel()
            {
                IsSuccess = true,
                Message = "Successfully Deleted",
                StatusCode = 200
            };
        }
    }
}
