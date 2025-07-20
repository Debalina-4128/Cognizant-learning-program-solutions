using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecureController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult GetSecret()
        {
            var username = User.Identity?.Name;
            return Ok($"Hello {username}, this is a protected endpoint!");
        }
    }
}
