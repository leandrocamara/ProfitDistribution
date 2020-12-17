using System;
using System.Collections.Generic;
using System.Linq;
using ProfitDistribution.Domain.Employees;
using ProfitDistribution.Domain.ValueObjects;
using ProfitDistribution.Exception.DomainExceptions;
using ProfitDistribution.Test.Unit.Domain.Employees;
using Xunit;

namespace ProfitDistribution.Test.Unit.Domain.Profits
{
    public class ProfitDistributionTest
    {
        [Fact]
        public void ProfitDistribution_AmountAvailableIsSufficient_ProfitDistributed()
        {
            // Arrange
            var amountAvailable = new Money(2150350);
            var employees = new List<Employee> {EmployeeTest.NewEmployee(), EmployeeTest.NewEmployee()};

            // Act
            var profitDistribution =
                ProfitDistribution.Domain.Profits.ProfitDistribution.New(employees, amountAvailable);

            // Assert
            var totalDistributed = profitDistribution.Participations.Sum(p => p.ParticipationValue.ToDouble());
            var totalBalanceAvailable = amountAvailable.ToDouble() - totalDistributed;

            Assert.NotNull(profitDistribution);
            Assert.Equal(employees.Count, profitDistribution.TotalEmployees);
            Assert.Equal(amountAvailable, profitDistribution.TotalAvailable);
            Assert.Equal(totalDistributed, profitDistribution.TotalDistributed.ToDouble());
            Assert.Equal(totalBalanceAvailable, profitDistribution.TotalBalanceAvailable.ToDouble());
        }

        [Fact]
        public void ProfitDistribution_AmountAvailableIsNegative_ProfitNotDistributed()
        {
            // Arrange
            var amountAvailable = new Money(-1000);
            var employees = new List<Employee> {EmployeeTest.NewEmployee(), EmployeeTest.NewEmployee()};

            // Act
            var exception = Record.Exception(() =>
                ProfitDistribution.Domain.Profits.ProfitDistribution.New(employees, amountAvailable));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<InvalidFieldException>(exception);
        }

        [Fact]
        public void ProfitDistribution_TotalBalanceAvailableIsNegative_ProfitNotDistributed()
        {
            // Arrange
            var amountAvailable = new Money(0);
            var employees = new List<Employee> {NewEmployee("R$ 5.000,00"), NewEmployee("R$ 8.000,00")};

            // Act
            var exception = Record.Exception(() =>
                ProfitDistribution.Domain.Profits.ProfitDistribution.New(employees, amountAvailable));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<DomainException>(exception);
        }

        private Employee NewEmployee(string grossSalary)
        {
            var admissionDate = DateTime.Now.AddYears(-10);
            return Employee.New(
                EmployeeTest.RegistrationValid,
                EmployeeTest.NameValid,
                EmployeeTest.AreaValid,
                EmployeeTest.PositionValid,
                grossSalary,
                admissionDate);
        }
    }
}