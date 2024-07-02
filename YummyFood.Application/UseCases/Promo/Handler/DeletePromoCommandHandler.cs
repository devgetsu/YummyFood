using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.Promo.Commands;
using YummyFood.Domain.Entities;
using YummyFood.Domain.Entities.DTOs;
using YummyFood.Domain.Exceptions;

namespace YummyFood.Application.UseCases.Promo.Handler
{
    public class DeletePromoCommandHandler : IRequestHandler<DeletePromoCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public DeletePromoCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeletePromoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request != null)
                {
                   var promo=_context.Promos.FirstOrDefaultAsync(x=>x.Id == request.Id).Result;
                    _context.Promos.Remove(promo);
                    _context.SaveChangesAsync();
                    return new ResponseModel()
                    {
                        Message = "Promo deleted",
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
