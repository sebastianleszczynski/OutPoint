using Microsoft.AspNetCore.Mvc;

namespace OutPoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register()
        {
            return Ok();
        }
    }
}