using Aquapets.Shared.Application.DTOs;
using Aquapets.Shared.Application.Services;
using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquapets.Shared.Infrastructure.Services
{
    public class LoginService : ILoginService<string, string>
    {
        public async Task<string> Login(LoginDto loginDto,string config)
        {
            FirebaseAuthProvider auth = new FirebaseAuthProvider(new FirebaseConfig(config));
            
            try
            {
                var fbAuthLink = await auth.SignInWithEmailAndPasswordAsync(loginDto.Email, loginDto.Password);
                var token = fbAuthLink.FirebaseToken;
                return token;

            }
            catch (FirebaseAuthException ex)
            {
                var firebaseEx = JsonConvert.DeserializeObject(ex.ResponseData);

                return firebaseEx.ToString();
            }
        }
    }
}
