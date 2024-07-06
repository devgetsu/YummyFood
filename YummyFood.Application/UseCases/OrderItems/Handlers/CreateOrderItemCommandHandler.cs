using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.OrderItems.Commands;
using YummyFood.Domain.Entities;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.Application.UseCases.OrderItems.Handlers
{
    public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public CreateOrderItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orderItem = new OrderItem()
            {
                OrderId = request.OrderId,
                DishId = request.DishId,
                Quantity = request.Quantity
            };

            await _context.OrderItems.AddAsync(orderItem, cancellationToken);
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
