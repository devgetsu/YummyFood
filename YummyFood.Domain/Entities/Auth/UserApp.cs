using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YummyFood.Domain.Entities.Auth
{
    public class UserApp : IdentityUser<long>
    {
        public string FullName { get; set; }
        public string Birth { get; set; }
        public string Gender { get; set; }
        public string ProfilePhoto { get; set; }
        public List<long> Cart { get; set; }
        public List<long> Favorite { get; set; }
        public List<Card> Cards { get; set; }
        public List<Address> Addresses { get; set; }
        //public List<Order> OrdersHistory { get; set; }
        public string? Password { get; set; }
        public string Role { get; set; }
    }
}
