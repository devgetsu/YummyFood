using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.Application.UseCases.Promo.Commands
{
    public class UpdatePromoCommand:IRequest<ResponseModel>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Condition { get; set; }
    }
}
