using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Xcomp.Api.Controllers.V1_0
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public string RequestUserId => User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value;
        public BaseController()
        {
        }
    }
}
