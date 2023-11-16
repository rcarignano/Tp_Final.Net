using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubits.Application.Exceptions
{
    public class NotFoundExeptions : Exception
    {
        public NotFoundExeptions() : base("NotFound") { }
        public NotFoundExeptions(string message) : base(message){ }
    }
}
