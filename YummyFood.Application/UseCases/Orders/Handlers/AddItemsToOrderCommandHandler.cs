using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.Orders.Commands;
using YummyFood.Domain.Entities;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.Application.UseCases.Orders.Handlers
{
    public class AddItemsToOrderCommandHandler : IRequestHandler<AddItemsToOrderCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public AddItemsToOrderCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(AddItemsToOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                .Include(o => o.Products)
                .FirstOrDefaultAsync(o => o.Id == request.OrderId, cancellationToken);

            if (order == null)
            {
                return new ResponseModel()
                {
                    IsSuccess = true,
                    Message = "Product Not found",
                    StatusCode = 404,
                };
            }

            foreach (var item in request.OrderItems)
            {
                var orderItem = new OrderItem
                {
                    OrderId = request.OrderId,
                    DishId = item.DishId,
                    Quantity = item.Quantity
                };

                order.Products.Add(orderItem);
            }

            await _context.SaveChangesAsync(cancellationToken);
            return new ResponseModel()
            {
                IsSuccess = true,
                Message = "Added",
                StatusCode = 201,
            };
        }
    }

}
