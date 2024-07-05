using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Entities;

namespace YummyFood.Application.UseCases.Promo.Queries
{
    public class GetAllPromoCommandQuery:IRequest<List<PromoModel>>
    {
    }
}
