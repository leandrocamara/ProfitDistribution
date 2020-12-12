using Microsoft.Extensions.DependencyInjection;

namespace ProfitDistribution.Shared
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddBootstrapperShared(this IServiceCollection services)
        {
            return services;
        }
    }
}