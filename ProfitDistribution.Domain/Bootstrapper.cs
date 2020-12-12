using Microsoft.Extensions.DependencyInjection;

namespace ProfitDistribution.Domain
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddBootstrapperDomain(this IServiceCollection services)
        {
            // services.AddScoped<IService, Service>();

            return services;
        }
    }
}