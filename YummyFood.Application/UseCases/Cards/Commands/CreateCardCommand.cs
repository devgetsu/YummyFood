using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.Application.UseCases.Cards.Commands
{
    public class CreateCardCommand : IRequest<ResponseModel>
    {
        public string Number { get; set; }
        public string Expired { get; set; }
        public short CVV { get; set; }
        public long UserId { get; set; }
    }
}
