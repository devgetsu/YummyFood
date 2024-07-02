using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Entities;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.Application.UseCases.Shops.Commands
{
    public class DeleteShopCommand : IRequest<ResponseModel>
    {
        public long Id { get; set; }
    }
}
