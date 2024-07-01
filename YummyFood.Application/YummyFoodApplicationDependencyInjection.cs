using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YummyFood.Application.Abstractions.AuthServices;

namespace YummyFood.Application
{
    public static class YummyFoodApplicationDependencyInjection
    {
        public static IServiceCollection AddYummyFoodApplicationDependencyInjection(this IServiceCollection services)
        {

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
