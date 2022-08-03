using Aquapets.Shared.Application.Builders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aquapets.Shared.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {

        [HttpPost]
        public IActionResult Post(string username, string password, string userRole)
        {
            UserBuilder userBuilder = new(username, password);
            var user = userBuilder.setRole(userRole);
            return Ok(user.Role.ToString());
        }
    }
}