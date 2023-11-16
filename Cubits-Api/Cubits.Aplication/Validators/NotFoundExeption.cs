using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubits.Application.Validators
{
    public class NotFoundExeption : Exception
    {
        public NotFoundExeption() : base("NotFound")
        {
        }

        public NotFoundExeption(string message) : base(message)
        {
        }
    }
}
