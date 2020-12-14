using Microsoft.Extensions.DependencyInjection;
using ProfitDistribution.Domain.Profits;
using ProfitDistribution.Domain.Profits.Interfaces;

namespace ProfitDistribution.Domain
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddBootstrapperDomain(this IServiceCollection services)
        {
            services.AddScoped<IProfitService, ProfitService>();

            return services;
        }
    }
}