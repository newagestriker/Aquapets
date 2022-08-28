using Aquapets.Shared.Api.ReceiveModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aquapets.Shared.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {

        [HttpGet]
        public ActionResult<UserIdReceiveModel> Get()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "user_id");
            if(userIdClaim != null )
            {
                return Ok(new UserIdReceiveModel(userIdClaim.Value));
            }
            return BadRequest();
          
        }
    }
}