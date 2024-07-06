using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.Comments.Queries;
using YummyFood.Domain.Entities;

namespace YummyFood.Application.UseCases.Comments.Handlers
{
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, CommentModel>
    {
        private readonly IApplicationDbContext _context;

        public GetCommentByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CommentModel> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments
                .Include(c => c.Shop)
                    .Include(c => c.User)
                        .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (comment == null)
            {
                throw new KeyNotFoundException("Comment not found");
            }

            return comment;
        }
    }

}
