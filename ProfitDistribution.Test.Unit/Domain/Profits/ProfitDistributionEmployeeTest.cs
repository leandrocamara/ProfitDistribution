using ProfitDistribution.Domain.Profits;
using ProfitDistribution.Domain.Profits.WeightsParticipation;
using ProfitDistribution.Exception.DomainExceptions;
using ProfitDistribution.Test.Unit.Domain.Employees;
using Xunit;

namespace ProfitDistribution.Test.Unit.Domain.Profits
{
    public class ProfitDistributionEmployeeTest
    {
        [Fact]
        public void ProfitDistributionEmployee_EmployeeIsNotNull_BonusCalculated()
        {
            // Arrange
            var employee = EmployeeTest.NewEmployee();

            const int numberMonthsYear = 12;
            var grossSalary = employee.GrossMoney.ToDouble();
            var weightSalaryRange = WeightSalaryRange.New(employee).Weight;
            var weightAdmissionDate = WeightAdmissionDate.New(employee).Weight;
            var weightOccupationArea = WeightOccupationArea.New(employee).Weight;

            var participationValue =
                ((grossSalary * weightAdmissionDate + grossSalary * weightOccupationArea) / weightSalaryRange) *
                numberMonthsYear;

            // Act
            var profitDistributionEmployee = ProfitDistributionEmployee.New(employee);

            // Assert
            Assert.NotNull(profitDistributionEmployee);
            Assert.Equal(participationValue, profitDistributionEmployee.ParticipationValue.ToDouble());
        }

        [Fact]
        public void ProfitDistributionEmployee_EmployeeIsNull_BonusNotCalculated()
        {
            // Arrange
            // Act
            var exception = Record.Exception(() => ProfitDistributionEmployee.New(null));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<InvalidFieldException>(exception);
        }
    }
}