using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.OrderItems.Commands;

namespace YummyFood.Application.UseCases.OrderItems.Handlers
{
    public class UpdateOrderItemCommandHandler : IRequestHandler<UpdateOrderItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateOrderItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orderItem = await _context.OrderItems.FindAsync(request.OrderItemId);
            if (orderItem == null)
            {
                throw new KeyNotFoundException("Order item not found");
            }

            orderItem.Quantity = request.Quantity;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
