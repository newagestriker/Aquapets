using Aquapets.Shared.Application.Services;
using Aquapets.Shared.Domain.Repositories;
using Aquapets.Shared.Infrastructure.DbContexts;
using Aquapets.Shared.Infrastructure.Repositories;
using Aquapets.Shared.Infrastructure.Services;
using Firebase.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Aquapets.Shared.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
        {

            serviceCollection.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddScoped<IAuthenticationService<FirebaseAuthLink, string, FirebaseAuthLink,string>, FirebaseAuthenticationService>(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                var httpContextAccessor = sp.GetRequiredService<IHttpContextAccessor>();
                return new FirebaseAuthenticationService(configuration["FirebaseApiKEY"]!, httpContextAccessor.HttpContext);
            });

            var configuration = serviceCollection.BuildServiceProvider().GetService<IConfiguration>();
            serviceCollection.AddDbContext<UserDbContext>(options => options.UseMySql(configuration.GetConnectionString("AquaPetsDatabase"), ServerVersion.AutoDetect(configuration.GetConnectionString("AquaPetsDatabase"))));

            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            return serviceCollection;

        }
    }
}
