using MediatR;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.Cards.Commands;
using YummyFood.Domain.Entities.DTOs;
using YummyFood.Domain.Exceptions;

namespace YummyFood.Application.UseCases.Cards.Handlers.CommandHandlers
{
    public class DeleteCardCommandHandler : IRequestHandler<DeleteCardCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCardCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteCardCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var card = await _context.Cards.FindAsync(request.Id);

                if (card is null)
                {
                    return new ResponseModel()
                    {
                        Message = "Not found",
                        IsSuccess = false,
                        StatusCode = 404
                    };
                }

                _context.Cards.Remove(card);

                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel()
                {
                    IsSuccess = true,
                    Message = "Successfully Deleted",
                    StatusCode = 200
                };
            }
            catch (Exception ex)
            {
                throw new ErrorDeletingData(ex.Message);
            }
        }
    }
}
