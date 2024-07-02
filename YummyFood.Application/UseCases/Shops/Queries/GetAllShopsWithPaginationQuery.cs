using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Entities;

namespace YummyFood.Application.UseCases.Shops.Queries
{
    public class GetAllShopsWithPaginationQuery : IRequest<IEnumerable<Shop>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
