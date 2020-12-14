using ProfitDistribution.Domain.Employees;
using ProfitDistribution.Domain.Profits.WeightsParticipation;

namespace ProfitDistribution.Domain.Profits
{
    public class ProfitDistributionEmployee
    {
        public Employee Employee { get; protected set; }
        public double ParticipationValue { get; protected set; }

        public static ProfitDistributionEmployee New(Employee employee)
        {
            var employeeProfitDistribution = new ProfitDistributionEmployee
            {
                Employee = employee
            };

            employeeProfitDistribution.Validate();
            employeeProfitDistribution.CalculateBonus();

            return employeeProfitDistribution;
        }

        private void CalculateBonus()
        {
            const int numberMonthsYear = 12;
            var grossSalary = Employee.GrossSalary.ToDouble();
            var weightSalaryRange = WeightSalaryRange.New(Employee).Weight;
            var weightAdmissionDate = WeightAdmissionDate.New(Employee).Weight;
            var weightOccupationArea = WeightOccupationArea.New(Employee).Weight;

            ParticipationValue = ((grossSalary * weightAdmissionDate + grossSalary * weightOccupationArea) /
                                  weightSalaryRange) * numberMonthsYear;
        }

        private void Validate()
        {
            // TODO
        }

        private ProfitDistributionEmployee()
        {
            ParticipationValue = 0;
        }
    }
}