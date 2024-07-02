using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.Promo.Commands;
using YummyFood.Domain.Entities.DTOs;
using YummyFood.Domain.Exceptions;

namespace YummyFood.Application.UseCases.Promo.Handler
{
    public class UpdatePromoCommandHanler : IRequestHandler<UpdatePromoCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public UpdatePromoCommandHanler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdatePromoCommand request, CancellationToken cancellationToken)
        {

            try
            {
                if (request != null)
                {
                    var promo = _context.Promos.FirstOrDefaultAsync(x => x.Id == request.Id).Result;
                    promo.Condition=request.Condition;
                    promo.Code=request.Code;
                    _context.Promos.Update(promo);
                    _context.SaveChangesAsync();
                    return new ResponseModel()
                    {
                        Message = "Promo update",
                        IsSuccess = true,
                        StatusCode = 400

                    };
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

