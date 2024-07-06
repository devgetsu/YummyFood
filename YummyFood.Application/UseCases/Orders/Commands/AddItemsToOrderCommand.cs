using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Entities.DTOs;

namespace YummyFood.Application.UseCases.Orders.Commands
{
    public class AddItemsToOrderCommand : IRequest<ResponseModel>
    {
        public int OrderId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
