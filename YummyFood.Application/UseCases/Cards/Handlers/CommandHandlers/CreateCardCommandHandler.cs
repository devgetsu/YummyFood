using MediatR;
using YummyFood.Domain.Entities.DTOs;
using YummyFood.Domain.Entities;
using YummyFood.Application.UseCases.Cards.Commands;
using YummyFood.Application.Abstractions;
using YummyFood.Domain.Exceptions;

namespace YummyFood.Application.UseCases.Cards.Handlers.CommandHandlers
{
    public class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _context;

        public CreateCardCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request != null)
                {
                    var card = new Card()
                    {
                        Number = request.Number,
                        Expired = request.Expired,
                        CVV = request.CVV,
                        UserId = request.UserId,
                        CreatedAt = DateTimeOffset.UtcNow
                    };

                    await _context.Cards.AddAsync(card, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);

                    return new ResponseModel()
                    {
                        Message = "Created",
                        IsSuccess = true,
                        StatusCode = 201
                    };
                }

                else
                {
                    throw new RequestNullException("Request is null here!");
                }
            }

            catch (Exception ex)
            {
                throw new ErrorCreatingData(ex.Message.ToString());
            }
        }
    }
}
