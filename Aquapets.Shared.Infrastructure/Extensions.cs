using Aquapets.Shared.Application.Services;
using Aquapets.Shared.Infrastructure.Services;
using Firebase.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Aquapets.Shared.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddFirebaseSignUp(this IServiceCollection serviceCollection)
        {

            serviceCollection.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddScoped<IAuthenticationService<FirebaseAuthLink, string, FirebaseAuthLink,string>, AuthenticationService>(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                var httpContextAccessor = sp.GetRequiredService<IHttpContextAccessor>();
                return new AuthenticationService(configuration["FirebaseApiKEY"]!, httpContextAccessor.HttpContext);
            });
            return serviceCollection;

        }
    }
}
