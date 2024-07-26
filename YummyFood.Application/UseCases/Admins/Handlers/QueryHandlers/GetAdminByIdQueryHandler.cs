using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.Admins.Query;
using YummyFood.Domain.Entities.Auth;
using YummyFood.Domain.Exceptions;

namespace YummyFood.Application.UseCases.Admins.Handlers.QueryHandlers
{
    public class GetAdminByIdQueryHandler : IRequestHandler<GetAdminByIdQuery, AdminApp>
    {
        private readonly IApplicationDbContext _context;

        public GetAdminByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AdminApp> Handle(GetAdminByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Admins.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                ?? throw new _404NotFoundException("Admin not found");
        }
    }
}
