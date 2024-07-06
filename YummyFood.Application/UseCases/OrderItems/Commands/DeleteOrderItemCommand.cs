using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YummyFood.Application.UseCases.OrderItems.Commands
{
    public class DeleteOrderItemCommand : IRequest
    {
        public int OrderItemId { get; set; }
    }
}
