using Aquapets.Shared.Application.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquapets.Shared.Application.Services
{
    public interface IAuthenticationService<TConfig, TLoginResult, TPasswordResetResult, TSignUpResult, TLogoutResult>
    {
        Task<TLoginResult> Login(LoginDto login, TConfig Config);
        Task<TPasswordResetResult> ResetPassword(string email, TConfig Config);
        Task<TSignUpResult> SignUp(SignUpDto signUpDto, TConfig Config);

        Task<TLogoutResult> Logout(HttpContext httpContext);
    }
}
