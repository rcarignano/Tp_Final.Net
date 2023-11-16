using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubits.Application.Contracts.GetClient
{
    public class GetClientRequest:IRequest<GetClientResponse>
    {
        public int ClientId { get; set; }
    }
}
