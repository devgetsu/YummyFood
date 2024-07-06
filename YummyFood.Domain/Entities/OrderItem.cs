using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Common;

namespace YummyFood.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public long OrderId { get; set; }
        public long DishId { get; set; }
        public int Quantity { get; set; }

        public Order Order { get; set; }
        public Product Dish { get; set; }
    }

}
