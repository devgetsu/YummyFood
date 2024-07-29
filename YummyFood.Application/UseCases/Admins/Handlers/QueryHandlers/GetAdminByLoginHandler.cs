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
    public class GetAdminByLoginHandler : IRequestHandler<GetAdminByLogin, AdminApp>
    {

        private readonly IApplicationDbContext _context;

        public GetAdminByLoginHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AdminApp> Handle(GetAdminByLogin request, CancellationToken cancellationToken)
        {
            return await _context.Admins.FirstOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber, cancellationToken) ?? throw new _404NotFoundException("Admin not found");
        }
    }
}
