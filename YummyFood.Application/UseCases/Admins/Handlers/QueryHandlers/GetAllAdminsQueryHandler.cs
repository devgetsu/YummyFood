using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.Addresses.Queries;
using YummyFood.Application.UseCases.Admins.Query;
using YummyFood.Domain.Entities.Auth;

namespace YummyFood.Application.UseCases.Admins.Handlers.QueryHandlers
{
    public class GetAllAdminsQueryHandler : IRequestHandler<GetAllAdminsQuery, IEnumerable<AdminApp>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllAdminsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AdminApp>> Handle(GetAllAdminsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Admins.ToListAsync(cancellationToken);
        }
    }
}
