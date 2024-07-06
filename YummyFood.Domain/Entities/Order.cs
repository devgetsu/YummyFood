using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Common;
using YummyFood.Domain.Entities.Auth;
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
        public long UserId { get; set; }
        public int RestaurantId { get; set; }

        public UserApp User { get; set; }
        public Shop Restaurant { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
