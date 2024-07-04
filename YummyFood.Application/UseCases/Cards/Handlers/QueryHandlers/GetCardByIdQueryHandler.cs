using MediatR;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.Cards.Queries;
using YummyFood.Domain.Entities;
using YummyFood.Domain.Exceptions;

namespace YummyFood.Application.UseCases.Cards.Handlers.QueryHandlers
{
    public class GetCardByIdQueryHandler : IRequestHandler<GetCardByIdQuery, Card>
    {
        private readonly IApplicationDbContext _context;

        public GetCardByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Card> Handle(GetCardByIdQuery request, CancellationToken cancellationToken)
        {
            var card = await _context.Cards.FindAsync(request.Id, cancellationToken) ?? throw new _404NotFoundException("Card not found!");
            
            return card;
        }
    }
}
