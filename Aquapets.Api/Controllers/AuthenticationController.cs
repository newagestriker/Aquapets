using Aquapets.Shared.Api.ActionFilterAttributes;
using Aquapets.Shared.Api.ReceiveModels;
using Aquapets.Shared.Application.DTOs;
using Aquapets.Shared.Application.Services;
using Firebase.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Aquapets.Shared.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [StringifyModelErrors]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IAuthenticationService<string, FirebaseAuthLink, string, FirebaseAuthLink,string> authenticationService;

        public AuthenticationController(IConfiguration configuration, IAuthenticationService<string, FirebaseAuthLink, string, FirebaseAuthLink,string> authenticationService)
        {
            this.configuration = configuration;
            this.authenticationService = authenticationService;
        }

        [HttpPost(nameof(SignUp))]
        public async Task<ActionResult<User>> SignUp([FromBody] SignUpDto signUpDto)
        {
           
                var firebaseAuthLink = await authenticationService.SignUp(signUpDto, configuration["FirebaseApiKEY"]);
                Response.Cookies.Append("X-Access-Token", firebaseAuthLink.FirebaseToken, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.None, Secure = true });

                return Ok(firebaseAuthLink.User);  

        }
        
        [HttpPost(nameof(Login))]
        public async Task<ActionResult<User>> Login([FromBody] LoginDto loginDto)
        {

            var firebaseAuthLink = await authenticationService.Login(loginDto, configuration["FirebaseApiKEY"]);

            Response.Cookies.Append("X-Access-Token", firebaseAuthLink.FirebaseToken, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.None, Secure = true });

            return Ok(firebaseAuthLink.User);


        }

        [HttpPost(nameof(ResetPassword))]
        public async Task<ActionResult<PasswordResetEmailConfirmationReceiveModel>> ResetPassword([Required,FromBody] string email)
        {

            string confirmation =  await authenticationService.ResetPassword(email, configuration["FirebaseApiKEY"]);


            return Ok(new PasswordResetEmailConfirmationReceiveModel(confirmation));

        }
        [Authorize]
        [HttpGet(nameof(Logout))]
        public async Task<ActionResult<LogoutReceiveModel>> Logout()
        {

            var message = await authenticationService.Logout(HttpContext);
           

            return Ok(new LogoutReceiveModel(message));

        }
    }
}
