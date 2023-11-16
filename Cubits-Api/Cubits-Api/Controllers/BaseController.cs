using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cubits_Api.Controllers
{
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class BaseController : ControllerBase
    {
        protected ISender Mediator => HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
