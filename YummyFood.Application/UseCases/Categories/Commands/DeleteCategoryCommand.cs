using MediatR;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.Application.UseCases.Categories.Commands
{
    public class DeleteCategoryCommand : IRequest<ResponseModel>
    {
        public long Id { get; set; }
    }
}
