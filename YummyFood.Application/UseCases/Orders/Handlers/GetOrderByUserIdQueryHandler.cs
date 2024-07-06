using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.Orders.Queries;
using YummyFood.Domain.Entities;

namespace YummyFood.Application.UseCases.Orders.Handlers
{
    public class GetOrderByUserIdQueryHandler : IRequestHandler<GetOrderByUserIdQuery, IEnumerable<Order>>
    {
        private readonly IApplicationDbContext _context;

        public GetOrderByUserIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> Handle(GetOrderByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Orders.Where(x => x.UserId == request.UserId)
                .Include(x => x.Restaurant)
                    .Include(x => x.User).ToListAsync(cancellationToken);
        }
    }
}
