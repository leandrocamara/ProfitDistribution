using Microsoft.Extensions.DependencyInjection;
using ProfitDistribution.Domain.Employees.Interfaces;
using ProfitDistribution.Infrastructure.Repository.Context;
using ProfitDistribution.Infrastructure.Repository.Repositories;

namespace ProfitDistribution.Infrastructure.Repository
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddBootstrapperRepository(this IServiceCollection services)
        {
            services.AddScoped<ProfitDistributionDbContext>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}