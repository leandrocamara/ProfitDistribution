using System;
using ProfitDistribution.Domain.Employees;
using ProfitDistribution.Domain.Profits.WeightsParticipation;
using ProfitDistribution.Domain.ValueObjects;
using ProfitDistribution.Exception.DomainExceptions;
using ProfitDistribution.Test.Unit.Domain.Employees;
using Xunit;

namespace ProfitDistribution.Test.Unit.Domain.Profits.WeightsParticipation
{
    public class WeightSalaryRangeTest
    {
        [Fact]
        public void WeightSalaryRange_PositionIsInternOrGrossMoneyIsLessThreeMinimumWages_WeightOneDefined()
        {
            // Arrange
            var twoMinimumWages = new Money(Money.MinimumSalaryWage * 2);
            var employeeIntern = NewEmployee(null, Position.Intern);
            var employeeLowPay = NewEmployee(twoMinimumWages.ToCurrency());

            // Act
            var weightSalaryRangeIntern = WeightSalaryRange.New(employeeIntern).Weight;
            var weightSalaryRangeLowPay = WeightSalaryRange.New(employeeLowPay).Weight;

            // Assert
            Assert.Equal(WeightParticipation.WeightOne, weightSalaryRangeIntern);
            Assert.Equal(WeightParticipation.WeightOne, weightSalaryRangeLowPay);
        }

        [Fact]
        public void WeightSalaryRange_GrossMoneyIsGreaterThreeMinimumWagesAndLessFiveMinimumWages_WeightTwoDefined()
        {
            // Arrange
            var fourMinimumWages = new Money(Money.MinimumSalaryWage * 4);
            var employee = NewEmployee(fourMinimumWages.ToCurrency());

            // Act
            var weightSalaryRange = WeightSalaryRange.New(employee).Weight;

            // Assert
            Assert.Equal(WeightParticipation.WeightTwo, weightSalaryRange);
        }

        [Fact]
        public void WeightSalaryRange_GrossMoneyIsGreaterFiveMinimumWagesAndLessEightMinimumWages_WeightThreeDefined()
        {
            // Arrange
            var sevenMinimumWages = new Money(Money.MinimumSalaryWage * 7);
            var employee = NewEmployee(sevenMinimumWages.ToCurrency());

            // Act
            var weightSalaryRange = WeightSalaryRange.New(employee).Weight;

            // Assert
            Assert.Equal(WeightParticipation.WeightThree, weightSalaryRange);
        }

        [Fact]
        public void WeightSalaryRange_GrossMoneyIsGreaterEightMinimumWages_WeightFiveDefined()
        {
            // Arrange
            var nineMinimumWages = new Money(Money.MinimumSalaryWage * 9);
            var employee = NewEmployee(nineMinimumWages.ToCurrency());

            // Act
            var weightSalaryRange = WeightSalaryRange.New(employee).Weight;

            // Assert
            Assert.Equal(WeightParticipation.WeightFive, weightSalaryRange);
        }

        [Fact]
        public void WeightSalaryRange_EmployeeIsNull_WeightNotDefined()
        {
            // Arrange
            // Act
            var exception = Record.Exception(() => WeightOccupationArea.New(null));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<InvalidFieldException>(exception);
        }

        private Employee NewEmployee(string grossSalary = null, string position = null)
        {
            var admissionDate = DateTime.Now.AddYears(-10);
            return Employee.New(
                EmployeeTest.RegistrationValid,
                EmployeeTest.NameValid,
                EmployeeTest.AreaValid,
                position ?? EmployeeTest.PositionValid,
                grossSalary ?? EmployeeTest.GrossSalaryValid,
                admissionDate);
        }
    }
}