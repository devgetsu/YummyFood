using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YummyFood.Domain.Exceptions
{
    public class RequestNullException : Exception
    {
        public RequestNullException(string message)
            : base(message)
        { }
    }
}
