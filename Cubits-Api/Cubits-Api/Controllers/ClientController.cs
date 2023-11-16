using Cubits.Application.Contracts;
using Cubits.Application.Contracts.GetClient;
using Cubits.Application.Contracts.GetClientList;
using Cubits.Domain.Ports;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace Cubits_Api.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("/api/v1/client")]  
    public class ClientController : BaseController
    {         
        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("")]
        public async Task<IActionResult> GetList()
        {
            var request = new GetClientListRequest();
            var response=await Mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{clientId:int}")]
        public async Task<IActionResult> Get([FromRoute] int clientId)
        {
            var request = new GetClientRequest { ClientId = clientId };
            var response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}
