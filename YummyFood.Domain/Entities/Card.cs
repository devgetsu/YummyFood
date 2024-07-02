using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Entities.Auth;

namespace YummyFood.Domain.Entities
{
    public class Card
    {
        public string Number { get; set; }
        public int CVV { get; set; }
        public long UserId { get; set; }
        public UserApp User { get; set; }
    }
}
