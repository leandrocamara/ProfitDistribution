using System.Threading.Tasks;
using ProfitDistribution.Domain.Employees.Interfaces;
using ProfitDistribution.Domain.Profits.Interfaces;

namespace ProfitDistribution.Domain.Profits
{
    public class ProfitService : IProfitService
    {
        private readonly IEmployeeRepository _employeeRepository;

        // public ProfitService(IEmployeeRepository employeeRepository)
        // {
        //     _employeeRepository = employeeRepository;
        // }

        public async Task<ProfitDistribution> GetProfitDistribution(double amountAvailable)
        {
            var employees = await _employeeRepository.GetAll();
            return ProfitDistribution.New(employees, amountAvailable);
        }
    }
}