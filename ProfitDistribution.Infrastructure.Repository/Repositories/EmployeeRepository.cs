using System.Collections.Generic;
using System.Threading.Tasks;
using ProfitDistribution.Domain.Employees;
using ProfitDistribution.Domain.Employees.Interfaces;
using ProfitDistribution.Infrastructure.Repository.Context;
using ProfitDistribution.Infrastructure.Repository.Repositories.Contracts;

namespace ProfitDistribution.Infrastructure.Repository.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee, EmployeeContract>, IEmployeeRepository
    {
        private const string ResourceName = "employees";

        public EmployeeRepository(ProfitDistributionDbContext context) : base(context, ResourceName)
        {
        }

        public async Task<IList<Employee>> GetAll()
        {
            return await GetAllAsync();
        }
    }
}