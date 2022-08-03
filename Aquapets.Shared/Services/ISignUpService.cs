using Aquapets.Shared.Application.DTOs;


namespace Aquapets.Shared.Application.Services
{
    public interface ISignUpService<TConfig, TResult>
    {
        Task<TResult> SignUp(SignUpDto signUpDto, TConfig config);
    }
}
