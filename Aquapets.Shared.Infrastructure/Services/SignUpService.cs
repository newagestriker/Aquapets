using Aquapets.Shared.Application.DTOs;
using Aquapets.Shared.Application.Services;
using Aquapets.Shared.Infrastructure.Models;
using Firebase.Auth;
using Newtonsoft.Json;

namespace Aquapets.Shared.Infrastructure.Services
{
    public class SignUpService : ISignUpService<string, string>
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


                return token;
            }
            catch (FirebaseAuthException ex)
            {
                var firebaseEx = JsonConvert.DeserializeObject<FirebaseErrorModel>(ex.ResponseData);

                throw new Exception(firebaseEx.error.message);
            }
        }


    }
}
