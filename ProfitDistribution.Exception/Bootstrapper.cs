using Microsoft.Extensions.DependencyInjection;

namespace ProfitDistribution.Exception
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddBootstrapperException(this IServiceCollection services)
        {
            return services;
        }
    }
}