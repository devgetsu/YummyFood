using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.OrderItems.Queries;
using YummyFood.Domain.Entities;

namespace YummyFood.Application.UseCases.OrderItems.Handlers
{
    public class GetOrderItemByIdQueryHandler : IRequestHandler<GetOrderItemByIdQuery, OrderItem>
    {
        private readonly IApplicationDbContext _context;

        public GetOrderItemByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<OrderItem> Handle(GetOrderItemByIdQuery request, CancellationToken cancellationToken)
        {
            var orderItem = await _context.OrderItems
                .Include(oi => oi.Dish)
                .FirstOrDefaultAsync(oi => oi.Id == request.OrderItemId);

            if (orderItem == null)
            {
                throw new KeyNotFoundException("Order item not found");
            }

            return orderItem;
        }
    }
}
