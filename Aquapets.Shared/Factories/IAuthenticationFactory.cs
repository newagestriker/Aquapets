using Aquapets.Shared.Application.DTOs;

namespace Aquapets.Shared.Infrastructure.Factories
{
    public interface IAuthenticationFactory<TLoginResult, TPasswordResetResult, TSignUpResult, TLogoutResult>
    {
        Task<TLoginResult> Login(LoginDto login);
        Task<TPasswordResetResult> ResetPassword(string email);
        Task<TSignUpResult> SignUp(SignUpDto signUpDto);

        Task<TLogoutResult> Logout();
    }
}
