using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.Application.UseCases.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<ResponseModel>
    {
        public string Name { get; set; }
        public IFormFile Sticker { get; set; }
    }
}
