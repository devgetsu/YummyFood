using MediatR;
using Microsoft.AspNetCore.Hosting;
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
    public class CreatePromoCommandHandler : IRequestHandler<CreatePromoCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreatePromoCommandHandler(IApplicationDbContext context,
            IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

       
        public async Task<ResponseModel> Handle(CreatePromoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if(request!=null)
                {
                    var promo = new PromoModel()
                    {
                        Code = request.Code,
                        Condition = request.Condition,
                    };
                    _context.Promos.Add(promo);
                    _context.SaveChangesAsync();
                    return new ResponseModel()
                    {
                        Message = "PromoCreated",
                        IsSuccess = true,
                        StatusCode=400
             
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
