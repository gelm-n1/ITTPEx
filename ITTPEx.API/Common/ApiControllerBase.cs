using Microsoft.AspNetCore.Mvc;

namespace ITTPEx.API.Common
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase { }
}
