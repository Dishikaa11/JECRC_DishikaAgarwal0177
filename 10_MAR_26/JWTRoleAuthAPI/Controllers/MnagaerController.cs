using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtRoleAuthAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ManagerController : ControllerBase
    {
        [HttpGet("dashboard")]
        [Authorize(Roles = "Manager")]
        public IActionResult GetManagerDashboard()
        {
            return Ok("Welcome to the Manager Dashboard! only users with the 'Manager' role can see this");
        }

        [HttpGet("reports")]
        [Authorize(Roles ="Admin,Manager")]
        public IActionResult GetManagerReports()
        {
            return Ok("Here are the manager reports! only users with the 'Admin' or 'Manager' role can see this");
        }
    }
}