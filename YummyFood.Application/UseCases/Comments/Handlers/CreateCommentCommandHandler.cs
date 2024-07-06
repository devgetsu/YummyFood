using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.Comments.Commands;
using YummyFood.Domain.Entities.DTOs;
using YummyFood.Domain.Entities;

namespace YummyFood.Application.UseCases.Comments.Handlers
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public CreateCommentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new CommentModel()
            {
                Rate = request.Rate,
                Feedback = request.Feedback,
                ShopId = request.ShopId,
                UserId = request.UserId,
                CreatedAt = DateTimeOffset.UtcNow,
            };

            await _context.Comments.AddAsync(comment, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseModel()
            {
                IsSuccess = true,
                Message = "Comment created successfully.",
                StatusCode = 201
            };
        }
    }

}
