using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.Application.UseCases.Orders.Commands
{
    public class CreateOrderCommand : IRequest<ResponseModel>
    {
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class OrderItemDto
    {
        public int DishId { get; set; }
        public int Quantity { get; set; }
    }

}
