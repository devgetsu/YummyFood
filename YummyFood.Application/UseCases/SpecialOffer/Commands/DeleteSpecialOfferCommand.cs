using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.Application.UseCases.SpecialOffer.Commands
{
    public class DeleteSpecialOfferCommand : IRequest<ResponseModel>
    {
        public int Id { get; set; }
    }
}
