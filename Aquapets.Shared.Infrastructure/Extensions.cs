using Aquapets.Shared.Application.Services;
using Aquapets.Shared.Infrastructure.Services;
using Firebase.Auth;
using Microsoft.Extensions.DependencyInjection;


namespace Aquapets.Shared.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddFirebaseSignUp(this IServiceCollection serviceCollection)
        {
      
            serviceCollection.AddScoped<IAuthenticationService<string, FirebaseAuthLink, string, FirebaseAuthLink,string>, AuthenticationService>();
            return serviceCollection;

        }
    }
}
