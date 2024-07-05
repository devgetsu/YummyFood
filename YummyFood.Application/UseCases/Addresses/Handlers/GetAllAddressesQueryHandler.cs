using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.Addresses.Queries;
using YummyFood.Domain.Entities;

namespace YummyFood.Application.UseCases.Addresses.Handlers
{
    public class GetAllAddressesQueryHandler : IRequestHandler<GetAllAddressesQuery, IEnumerable<Address>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllAddressesQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Address>> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Addresses.Skip(request.PageIndex - 1).Take(request.PageSize).ToListAsync(cancellationToken);
        }
    }
}
