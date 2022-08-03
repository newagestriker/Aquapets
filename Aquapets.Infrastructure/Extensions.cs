using Aquapets.Application.Services;
using Aquapets.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquapets.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddFirebaseSignUp(this IServiceCollection services)
        {
            services.AddScoped<ISignUpService, SignUpService>();
            return services;
        }
    }
}
