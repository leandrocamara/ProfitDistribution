using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
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
        public static IServiceCollection AddBootstrapperIoC(this IServiceCollection services)
        {
            services.AddBootstrapperApplicationAbstraction()
                .AddBootstrapperApplication()
                .AddBootstrapperException()
                .AddBootstrapperShared()
                .AddBootstrapperDomain()
                .AddBootstrapperRepository();

            services.AddScoped(s => new HttpClient(new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) => true
            }));

            return services;
        }
    }
}