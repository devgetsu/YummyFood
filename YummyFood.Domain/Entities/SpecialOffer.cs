using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Domain.Common;

namespace YummyFood.Domain.Entities
{
    public class SpecialOffer : AudiTable
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
    }
}
