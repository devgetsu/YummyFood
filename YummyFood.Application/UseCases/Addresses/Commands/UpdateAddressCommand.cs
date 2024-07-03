using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.Application.UseCases.Addresses.Commands
{
    public class UpdateAddressCommand : IRequest<ResponseModel>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Lat { get; set; }
        public long Long { get; set; }
    }
}
