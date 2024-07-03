using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Entities;

namespace YummyFood.Application.UseCases.Addresses.Queries
{
    public class GetAllAddressesQuery : IRequest<IEnumerable<Address>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
