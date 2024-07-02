using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YummyFood.Domain.Exceptions
{
    public class ErrorCreatingData : Exception
    {
        public ErrorCreatingData(string message)
            : base(message)
        { }
    }
}
