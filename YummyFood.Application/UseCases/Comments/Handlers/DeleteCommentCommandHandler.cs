using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.Comments.Commands;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.Application.UseCases.Comments.Handlers
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCommentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.FindAsync(request.Id);
            if (comment == null)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = "Comment not found.",
                    StatusCode = 404
                };
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseModel
            {
                IsSuccess = true,
                Message = "Comment deleted successfully.",
                StatusCode = 200
            };
        }
    }

}
