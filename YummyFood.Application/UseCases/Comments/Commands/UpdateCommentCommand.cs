using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.Application.UseCases.Comments.Commands
{
    public class UpdateCommentCommand : IRequest<ResponseModel>
    {
        public long Id { get; set; }
        public short Rate { get; set; }
        public string? Feedback { get; set; }
    }

}
