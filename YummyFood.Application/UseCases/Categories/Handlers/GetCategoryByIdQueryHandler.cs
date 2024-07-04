using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.Categories.Queries;
using YummyFood.Domain.Entities;
using YummyFood.Domain.Exceptions;

namespace YummyFood.Application.UseCases.Categories.Handlers
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Category>
    {
        private readonly IApplicationDbContext _context;

        public GetCategoryByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Categories.FindAsync(request.Id, cancellationToken) ?? throw new _404NotFoundException("Cateogry not found");
        }
    }
}
