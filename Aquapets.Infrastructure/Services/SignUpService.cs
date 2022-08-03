using Aquapets.Application.DTOs;
using Aquapets.Application.Services;
using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquapets.Infrastructure.Services
{
    public class SignUpService : ISignUpService
    {
        public async Task<string> SignUp(SignUpDto signUpDto, string config)
        {

            FirebaseAuthProvider auth = new FirebaseAuthProvider(new FirebaseConfig(config));
           
            try
            {
               
                await auth.CreateUserWithEmailAndPasswordAsync(signUpDto.Email, signUpDto.Password);
               
                var fbAuthLink = await auth
                                .SignInWithEmailAndPasswordAsync(signUpDto.Email, signUpDto.Password);
                string token = fbAuthLink.FirebaseToken;
               
                
                return (token);
            }
            catch (FirebaseAuthException ex)
            {
                var firebaseEx = JsonConvert.DeserializeObject(ex.ResponseData);

                return (firebaseEx.ToString());
            }
        }

      
    }
}
