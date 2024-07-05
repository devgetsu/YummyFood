using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Entities;

namespace YummyFood.Application.UseCases.SpecialOffer.Queries
{
    public class GetAllSpecialOfferCommandQuery :IRequest<List<SpecialOfferModel>>
    {
    }
}
