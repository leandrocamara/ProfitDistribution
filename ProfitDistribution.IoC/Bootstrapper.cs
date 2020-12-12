using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProfitDistribution.Application;
using ProfitDistribution.Application.Abstraction;
using ProfitDistribution.Domain;
using ProfitDistribution.Exception;
using ProfitDistribution.Infrastructure.Repository;
using ProfitDistribution.Shared;

namespace ProfitDistribution.IoC
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddBootstrapperIoC(
            this IServiceCollection services,
            IConfiguration configuration,
            IHostEnvironment env)
        {
            services.AddBootstrapperApplicationAbstraction()
                .AddBootstrapperApplication()
                .AddBootstrapperException()
                .AddBootstrapperShared()
                .AddBootstrapperDomain()
                .AddBootstrapperRepository(configuration, env);

            services.AddScoped(s => new HttpClient(new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) => true
            }));

            return services;
        }
    }
}