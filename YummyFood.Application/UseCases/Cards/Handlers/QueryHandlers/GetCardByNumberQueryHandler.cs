using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.Cards.Queries;
using YummyFood.Domain.Entities;
using YummyFood.Domain.Exceptions;

namespace YummyFood.Application.UseCases.Cards.Handlers.QueryHandlers
{
    public class GetCardByNumberQueryHandler : IRequestHandler<GetCardByNumberQuery, Card>
    {
        private readonly IApplicationDbContext _context;

        public GetCardByNumberQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Card> Handle(GetCardByNumberQuery request, CancellationToken cancellationToken)
        {
            var card = await _context.Cards.FindAsync(request.Number, cancellationToken) ?? throw new _404NotFoundException("Card not found!");

            return card;
        }
    }
}
