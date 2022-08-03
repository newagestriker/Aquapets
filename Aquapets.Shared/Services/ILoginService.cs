
using Aquapets.Shared.Application.DTOs;

namespace Aquapets.Shared.Application.Services
{
    public interface ILoginService<TConfig, TResult>
    {
        Task<TResult> Login(LoginDto login, TConfig config);
    }
}
