using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("v{vrsn:apiVersion}/mobile")]
    public abstract class MobileControllerBase : ControllerBase
    {
    }
}