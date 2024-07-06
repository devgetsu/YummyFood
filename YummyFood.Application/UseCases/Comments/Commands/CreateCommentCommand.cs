using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.Application.UseCases.Comments.Commands
{
    public class CreateCommentCommand : IRequest<ResponseModel>
    {
        public short Rate { get; set; }
        public string? Feedback { get; set; }
        public long ShopId { get; set; }
        public long UserId { get; set; }
    }

}
