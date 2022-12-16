using Aquapets.Shared.Api.ReceiveModels;
using Aquapets.Shared.Domain.Entities;
using Aquapets.Shared.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aquapets.Shared.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        [HttpGet]
        public ActionResult<UserIdReceiveModel> Get()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "user_id");
            if(userIdClaim != null )
            {
                var user = new User("ramiz","");
                var user2 = userRepository.AddUser(user);
                return Ok(new UserIdReceiveModel(userIdClaim.Value));
            }
            return BadRequest();
          
        }
    }
}