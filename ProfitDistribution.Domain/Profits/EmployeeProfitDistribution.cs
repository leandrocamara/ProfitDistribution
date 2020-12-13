using ProfitDistribution.Domain.Employees;

namespace ProfitDistribution.Domain.Profits
{
    public class EmployeeProfitDistribution
    {
        public Employee Employee { get; protected set; }
        public double ParticipationValue { get; protected set; }

        public static EmployeeProfitDistribution New(Employee employee, double participationValue)
        {
            var employeeProfitDistribution = new EmployeeProfitDistribution
            {
                Employee = employee,
                ParticipationValue = participationValue
            };

            employeeProfitDistribution.Validate();

            return employeeProfitDistribution;
        }

        private void Validate()
        {
        }

        private EmployeeProfitDistribution()
        {
        }
    }
}