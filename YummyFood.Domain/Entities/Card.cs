using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Common;
using YummyFood.Domain.Entities.Auth;

namespace YummyFood.Domain.Entities
{
    public class Card : AudiTable
    {
        public string Number { get; set; }
        public string Expired { get; set; }
        public short CVV { get; set; }
        public long UserId { get; set; }
        public UserApp User { get; set; }
    }
}
