using MediatR;
using Microsoft.EntityFrameworkCore;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.Cards.Queries;
using YummyFood.Domain.Entities;

namespace YummyFood.Application.UseCases.Cards.Handlers.QueryHandlers
{
    public class GetAllCardsQueryHandler : IRequestHandler<GetAllCardsQuery, IEnumerable<Card>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllCardsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Card>> Handle(GetAllCardsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Cards.ToListAsync(cancellationToken);
        }
    }
}
