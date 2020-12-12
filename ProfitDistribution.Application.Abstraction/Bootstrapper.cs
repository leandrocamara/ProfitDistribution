using Microsoft.Extensions.DependencyInjection;

namespace ProfitDistribution.Application.Abstraction
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddBootstrapperApplicationAbstraction(this IServiceCollection services)
        {
            return services;
        }
    }
}