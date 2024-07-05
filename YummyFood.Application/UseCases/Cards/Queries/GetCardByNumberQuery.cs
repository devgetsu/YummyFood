using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Entities;

namespace YummyFood.Application.UseCases.Cards.Queries
{
    public class GetCardByNumberQuery : IRequest<Card>
    {
        public long Number { get; set; }
    }
}
