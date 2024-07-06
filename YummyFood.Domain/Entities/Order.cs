using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Common;
using YummyFood.Domain.Enums;

namespace YummyFood.Domain.Entities
{
    public class Order : AudiTable
    {
        public OrderStatus Status { get; set; }
        public List<long> Products { get; set; }
        public decimal QuantityPrice { get; set; }
        public decimal ShippingFree { get; set; }
        public decimal TotalPrice { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
