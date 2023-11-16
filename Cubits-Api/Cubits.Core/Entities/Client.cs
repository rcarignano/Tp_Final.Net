using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubits.Domain.Entities
{
    public class Client
    {
        public int ClientId { get; set; }
        public string? Name { get; set; }
        public string? StreetName { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string? Region { get; set; }
    }
}
