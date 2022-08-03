using Aquapets.Shared.Application.Services;
using Firebase.Auth;

namespace Aquapets.Shared.Infrastructure.Services
{
    public class LogoutService : ILogoutService<string, string>
    {
       

        public async Task<string> Logout(string config) 
        {
            FirebaseAuthProvider auth = new FirebaseAuthProvider(new FirebaseConfig(config));
             try
            {

               

               
            }
            catch (FirebaseAuthException ex)
            {
               
            }
            return "";
        }
    }
}
