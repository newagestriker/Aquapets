using Aquapets.Shared.Application.Services;
using Aquapets.Shared.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;


namespace Aquapets.Shared.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddFirebaseSignUp(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ISignUpService<string,string>, SignUpService>();
            serviceCollection.AddScoped<ILoginService<string,string>, LoginService>();
            return serviceCollection;

        }
    }
}
