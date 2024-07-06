using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YummyFood.Application.UseCases.OrderItems.Commands
{
    public class UpdateOrderItemCommand : IRequest
    {
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
    }
}
