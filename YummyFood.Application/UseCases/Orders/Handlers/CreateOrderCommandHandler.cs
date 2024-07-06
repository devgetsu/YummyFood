using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.Orders.Commands;
using YummyFood.Domain.Entities;
using YummyFood.Domain.Entities.DTOs;
using YummyFood.Domain.Enums;

namespace YummyFood.Application.UseCases.Orders.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public CreateOrderCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                UserId = request.UserId,
                RestaurantId = request.RestaurantId,
                TotalAmount = request.TotalAmount,
                Status = OrderStatus.Pending,
                Products = request.OrderItems.Select(oi => new OrderItem
                {
                    DishId = oi.DishId,
                    Quantity = oi.Quantity
                }).ToList()
            };

            await _context.Orders.AddAsync(order, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseModel()
            {
                Message = "Successfully created",
                IsSuccess = true,
                StatusCode = 201
            };
        }
    }
}
