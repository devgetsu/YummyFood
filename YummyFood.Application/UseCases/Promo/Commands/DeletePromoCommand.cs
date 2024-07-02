using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.Application.UseCases.Promo.Commands
{
    public class DeletePromoCommand:IRequest<ResponseModel>
    {
        public int Id { get; set; }
    }
}
