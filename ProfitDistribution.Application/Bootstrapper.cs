using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ProfitDistribution.Application
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddBootstrapperApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}