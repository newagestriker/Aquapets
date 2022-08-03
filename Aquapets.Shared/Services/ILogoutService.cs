using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquapets.Shared.Application.Services
{
    public interface ILogoutService<TConfig,TResult>
    {
        Task<TResult> Logout(TConfig config);
    }
}
