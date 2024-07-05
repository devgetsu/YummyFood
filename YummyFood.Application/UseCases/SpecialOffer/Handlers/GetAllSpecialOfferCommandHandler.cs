using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.SpecialOffer.Queries;
using YummyFood.Domain.Entities;
using YummyFood.Domain.Exceptions;

namespace YummyFood.Application.UseCases.SpecialOffer.Handlers
{
    public class GetAllSpecialOfferCommandHandler : IRequestHandler<GetAllSpecialOfferCommandQuery, List<SpecialOfferModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllSpecialOfferCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<SpecialOfferModel>> Handle(GetAllSpecialOfferCommandQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (request != null)
                {

                    return _context.SpecialOffers.ToListAsync();
                }
                else
                {
                    throw new RequestNullException("Request is null here.");
                }


            }

            catch (Exception ex)
            {
                throw new ErrorCreatingData(ex.Message.ToString());
            }
        }

    }

}
