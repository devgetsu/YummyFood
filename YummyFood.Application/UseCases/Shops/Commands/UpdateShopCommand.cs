using MediatR;
using Microsoft.AspNetCore.Http;
using YummyFood.Domain.Entities;
using YummyFood.Domain.Entities.DTOs;
using YummyFood.Domain.Enums;

namespace YummyFood.Application.UseCases.Shops.Commands
{
    public class UpdateShopCommand : IRequest<ResponseModel>
    {
        public long Id { get; set; }
        public long AddressId { get; set; }
        public string Name { get; set; }
        public IFormFile Photo { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public IFormFile PreviewPhoto { get; set; }
        public string TimeTableWeekday { get; set; }
        public string TimeTableWeekend { get; set; }
        public ShopStatus Status { get; set; }
    }
}
