using Aquapets.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquapets.Application.Services
{
    public interface ISignUpService
    {
         Task<string> SignUp(SignUpDto signUpDto, string config);
    }
}
