using System.Threading.Tasks;
using ProfitDistribution.Domain.Employees.Interfaces;
using ProfitDistribution.Domain.Profits.Interfaces;
using ProfitDistribution.Domain.ValueObjects;

namespace ProfitDistribution.Domain.Profits
{
    public class ProfitService : IProfitService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public ProfitService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<ProfitDistribution> GetProfitDistribution(Money amountAvailable)
        {
            var employees = await _employeeRepository.GetAll();
            return ProfitDistribution.New(employees, amountAvailable);
        }
    }
}