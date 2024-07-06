using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.Application.UseCases.OrderItems.Commands
{
    public class CreateOrderItemCommand : IRequest<ResponseModel>
    {
        public int OrderId { get; set; }
        public int DishId { get; set; }
        public int Quantity { get; set; }
    }
}
