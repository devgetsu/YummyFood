using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.SpecialOffer.Commands;
using YummyFood.Domain.Entities;
using YummyFood.Domain.Entities.DTOs;
using YummyFood.Domain.Exceptions;

namespace YummyFood.Application.UseCases.SpecialOffer.Handlers
{
    public class CreateSpecialOfferCommandHandler : IRequestHandler<CreateSpecialOfferCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public CreateSpecialOfferCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateSpecialOfferCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request != null)
                {
                    var promo = new SpecialOfferModel()
                    {
                        Title = request.Title,
                       Subtitle = request.Subtitle,
                    };
                    _context.SpecialOffers.Add(promo);
                    _context.SaveChangesAsync();
                    return new ResponseModel()
                    {
                        Message = "PromoCreated",
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
