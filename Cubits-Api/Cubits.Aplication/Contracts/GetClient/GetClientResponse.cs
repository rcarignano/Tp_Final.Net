using Cubits.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubits.Application.Contracts.GetClient
{
    public class GetClientResponse
    {
        public ClientDto? Client { get; set; }
    }
}
