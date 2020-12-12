using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ProfitDistribution.Infrastructure.Repository
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddBootstrapperRepository(
            this IServiceCollection services,
            IConfiguration configuration,
            IHostEnvironment env,
            string configConnectionString = "DefaultConnection")
        {
            ConfigureDbContext(services, configuration, env, configConnectionString);

            // services.AddScoped<IRepository, Repository>();

            return services;
        }

        private static void ConfigureDbContext(
            IServiceCollection services,
            IConfiguration configuration,
            IHostEnvironment env,
            string configConnectionString)
        {
            // services.AddScoped<DbContext>(s => s.GetService<ProfitDistributionDbContext>());
        }
    }
}