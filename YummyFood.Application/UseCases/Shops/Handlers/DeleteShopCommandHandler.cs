using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.Shops.Commands;
using YummyFood.Domain.Entities;
using YummyFood.Domain.Exceptions;

namespace YummyFood.Application.UseCases.Shops.Handlers
{
    public class DeleteShopCommandHandler : IRequestHandler<DeleteShopCommand, Shop>
    {
        private readonly IApplicationDbContext _context;

        public DeleteShopCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Shop> Handle(DeleteShopCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var shop = await _context.Shops.FindAsync(request.Id) ?? throw new _404NotFoundException("Shop not found!");

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
                return shop;
            }
            catch (Exception ex)
            {
                throw new ErrorDeletingData(ex.Message);
            }
        }
    }
}
