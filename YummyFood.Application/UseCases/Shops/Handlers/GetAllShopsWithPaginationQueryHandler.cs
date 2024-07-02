using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.Shops.Queries;
using YummyFood.Domain.Entities;

namespace YummyFood.Application.UseCases.Shops.Handlers
{
    public class GetAllShopsWithPaginationQueryHandler : IRequestHandler<GetAllShopsWithPaginationQuery, IEnumerable<Shop>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllShopsWithPaginationQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Shop>> Handle(GetAllShopsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Shops.Skip(request.PageIndex - 1).Take(request.PageSize).ToListAsync(cancellationToken);
        }
    }
}
