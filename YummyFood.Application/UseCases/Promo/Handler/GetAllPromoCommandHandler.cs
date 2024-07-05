using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.Promo.Queries;
using YummyFood.Domain.Entities;
using YummyFood.Domain.Entities.DTOs;
using YummyFood.Domain.Exceptions;

namespace YummyFood.Application.UseCases.Promo.Handler
{
    public class GetAllPromoCommandHandler : IRequestHandler<GetAllPromoCommandQuery, List<PromoModel>>
    {
        private readonly IApplicationDbContext _context;
        public GetAllPromoCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public Task<List<PromoModel>> Handle(GetAllPromoCommandQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (request != null)
                {
                    
                    return _context.Promos.ToListAsync(cancellationToken);
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
