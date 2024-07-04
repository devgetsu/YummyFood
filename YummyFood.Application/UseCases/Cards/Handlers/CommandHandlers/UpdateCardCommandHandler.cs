using MediatR;
using YummyFood.Application.Abstractions;
using YummyFood.Application.UseCases.Cards.Commands;
using YummyFood.Domain.Entities.DTOs;
using YummyFood.Domain.Exceptions;

namespace YummyFood.Application.UseCases.Cards.Handlers.CommandHandlers
{
    public class UpdateCardCommandHandler : IRequestHandler<UpdateCardCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCardCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateCardCommand request, CancellationToken cancellationToken)
        {
            var card = await _context.Cards.FindAsync(request.Id, cancellationToken) ?? throw new _404NotFoundException("Shop not found!");

            try
            {
                if (request != null)
                {
                    card.Number = request.Number;
                    card.Expired = request.Expired;
                    card.CVV = request.CVV;
                    card.UserId = request.UserId;
                    card.ModifiedAt = DateTimeOffset.UtcNow;

                    _context.Cards.Update(card);
                    await _context.SaveChangesAsync(cancellationToken);

                    return new ResponseModel()
                    {
                        IsSuccess = true,
                        Message = "Successfully Updated",
                        StatusCode = 200,
                    };
                }
                else
                {
                    throw new RequestNullException("Request is null here.");
                }
            }

            catch (Exception ex)
            {
                throw new ErrorUpdatingData(ex.Message.ToString());
            }
        }
    }
}
