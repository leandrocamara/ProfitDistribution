using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProfitDistribution.Domain.Employees.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAll();
    }
}