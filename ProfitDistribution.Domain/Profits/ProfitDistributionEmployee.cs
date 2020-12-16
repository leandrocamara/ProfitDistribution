using ProfitDistribution.Domain.Employees;
using ProfitDistribution.Domain.Profits.WeightsParticipation;
using ProfitDistribution.Domain.ValueObjects;

namespace ProfitDistribution.Domain.Profits
{
    public class ProfitDistributionEmployee
    {
        public Employee Employee { get; protected set; }
        public Money ParticipationValue { get; protected set; }

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
            var grossSalary = Employee.GrossMoney.ToDouble();
            var weightSalaryRange = WeightSalaryRange.New(Employee).Weight;
            var weightAdmissionDate = WeightAdmissionDate.New(Employee).Weight;
            var weightOccupationArea = WeightOccupationArea.New(Employee).Weight;

            var participationValue =
                ((grossSalary * weightAdmissionDate + grossSalary * weightOccupationArea) / weightSalaryRange) *
                numberMonthsYear;

            ParticipationValue = new Money(participationValue);
        }

        private void Validate()
        {
            // TODO
        }

        private ProfitDistributionEmployee()
        {
            ParticipationValue = new Money(0);
        }
    }
}