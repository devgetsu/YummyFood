using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Common;
using YummyFood.Domain.Enums;

namespace YummyFood.Domain.Entities
{
    public class Shop : AudiTable
    {
        public int Rate { get; set; }
        public long AddressId { get; set; }
        public string Name {  get; set; }
        public string Photo {  get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string PreviewPhoto { get; set; }
        public string TimeTableWeekday { get; set; }
        public string TimeTableWeekend { get; set; }

        public Address? Address { get; set; }
        public ShopStatus Status { get; set; }
        public List<CommentModel>? Comments { get; set; }
    }
}
