using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace JwtRoleAuthAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        // This endpoint is protected and requires the user to be authenticated
        [HttpGet("dashboard")]
        [Authorize(Roles = "User")]
        public IActionResult GetUserDashboard()
        {
            return Ok(new { message = "Welcome to your dashboard! only authenticated users can see this" });
        }
    }
}