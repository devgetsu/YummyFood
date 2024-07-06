
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Entities;

namespace YummyFood.Application.UseCases.Orders.Queries
{
    public class GetOrderByUserIdQuery : IRequest<IEnumerable<Order>>
    {
        public long UserId { get; set; }
    }
}
