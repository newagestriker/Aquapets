using Aquapets.Application.Builder;
using Microsoft.AspNetCore.Mvc;

namespace Aquapets.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
       

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post(string username, string password, string userRole)
        {
            UserBuilder userBuilder = new(username,password);
            var user = userBuilder.setRole(userRole);
            return Ok(user.Role.ToString());
        }
    }
}