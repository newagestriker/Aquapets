using Aquapets.Shared.Api.Exceptions;
using Aquapets.Shared.Application.DTOs;
using Aquapets.Shared.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aquapets.Shared.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly ISignUpService<string, string> signUpService;
        private readonly ILoginService<string, string> loginService;

        public AuthenticationController(IConfiguration configuration, ISignUpService<string, string> signUpService, ILoginService<string, string> loginService)
        {
            this.configuration = configuration;
            this.signUpService = signUpService;
            this.loginService = loginService;
        }

        [HttpPost(nameof(SignUp))]
        public async Task<IActionResult> SignUp([FromBody] SignUpDto signUpDto)
        {
            try
            {
                var token = await signUpService.SignUp(signUpDto, configuration["FirebaseApiKEY"]);
                Response.Cookies.Append("X-Access-Token", token, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.None, Secure = true });

                return Ok(token);
            }
            catch (Exception ex)
            {
                throw new RegisterUserException(ex.Message);
            }

        }

        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {

            var token = await loginService.Login(loginDto, configuration["FirebaseApiKEY"]);

            Response.Cookies.Append("X-Access-Token", token, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.None, Secure = true });

            return Ok(token);


        }
    }
}
