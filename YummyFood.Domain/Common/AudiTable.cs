using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YummyFood.Domain.Common
{
    public abstract class AudiTable : BaseEntity
    {
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset ModifiedAt { get; set; }
        public DateTimeOffset DeletedAt { get; set; }
    }
}
