using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Common;

namespace YummyFood.Domain.Entities
{
    public class Product : AudiTable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }
        public long CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
