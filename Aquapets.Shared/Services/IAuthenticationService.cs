using Aquapets.Shared.Application.DTOs;
using Aquapets.Shared.Infrastructure.Factories;
using Microsoft.AspNetCore.Http;


namespace Aquapets.Shared.Application.Services
{
    public interface IAuthenticationService<TLoginResult, TPasswordResetResult, TSignUpResult, TLogoutResult> : IAuthenticationFactory<TLoginResult, TPasswordResetResult, TSignUpResult, TLogoutResult>
    {

    }
}
