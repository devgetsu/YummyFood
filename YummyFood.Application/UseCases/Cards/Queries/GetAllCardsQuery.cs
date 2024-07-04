using MediatR;
using YummyFood.Domain.Entities;

namespace YummyFood.Application.UseCases.Cards.Queries
{
    public class GetAllCardsQuery : IRequest<IEnumerable<Card>>
    {
    }
}
