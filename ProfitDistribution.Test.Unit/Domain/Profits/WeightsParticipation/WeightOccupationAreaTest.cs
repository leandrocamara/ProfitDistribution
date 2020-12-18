using System;
using ProfitDistribution.Domain.Employees;
using ProfitDistribution.Domain.Profits.WeightsParticipation;
using ProfitDistribution.Domain.ValueObjects;
using ProfitDistribution.Exception.DomainExceptions;
using ProfitDistribution.Test.Unit.Domain.Employees;
using Xunit;

namespace ProfitDistribution.Test.Unit.Domain.Profits.WeightsParticipation
{
    public class WeightOccupationAreaTest
    {
        [Fact]
        public void WeightOccupationArea_OccupationAreaIsBoardDirectors_WeightOneDefined()
        {
            // Arrange
            var employee = NewEmployee(OccupationArea.BoardDirectors);

            // Act
            var weightOccupationArea = WeightOccupationArea.New(employee).Weight;

            // Assert
            Assert.Equal(WeightParticipation.WeightOne, weightOccupationArea);
        }

        [Fact]
        public void WeightOccupationArea_OccupationAreaIsAccountingOrFinancialOrTechnology_WeightTwoDefined()
        {
            // Arrange
            var employeeAccounting = NewEmployee(OccupationArea.Accounting);
            var employeeFinancial = NewEmployee(OccupationArea.Financial);
            var employeeTechnology = NewEmployee(OccupationArea.Technology);

            // Act
            var weightOccupationAreaAccounting = WeightOccupationArea.New(employeeAccounting).Weight;
            var weightOccupationAreaFinancial = WeightOccupationArea.New(employeeFinancial).Weight;
            var weightOccupationAreaTechnology = WeightOccupationArea.New(employeeTechnology).Weight;

            // Assert
            Assert.Equal(WeightParticipation.WeightTwo, weightOccupationAreaAccounting);
            Assert.Equal(WeightParticipation.WeightTwo, weightOccupationAreaFinancial);
            Assert.Equal(WeightParticipation.WeightTwo, weightOccupationAreaTechnology);
        }

        [Fact]
        public void WeightOccupationArea_OccupationAreaIsGeneralServices_WeightThreeDefined()
        {
            // Arrange
            var employee = NewEmployee(OccupationArea.GeneralServices);

            // Act
            var weightOccupationArea = WeightOccupationArea.New(employee).Weight;

            // Assert
            Assert.Equal(WeightParticipation.WeightThree, weightOccupationArea);
        }

        [Fact]
        public void WeightOccupationArea_OccupationAreaIsCustomerRelationship_WeightFiveDefined()
        {
            // Arrange
            var employee = NewEmployee(OccupationArea.CustomerRelationship);

            // Act
            var weightOccupationArea = WeightOccupationArea.New(employee).Weight;

            // Assert
            Assert.Equal(WeightParticipation.WeightFive, weightOccupationArea);
        }

        [Fact]
        public void WeightOccupationArea_OccupationAreaNotIncludedDistributionProfits_WeightNotDefined()
        {
            // Arrange
            var employee = NewEmployee("Segurança");
            
            // Act
            var exception = Record.Exception(() => WeightOccupationArea.New(employee));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<DomainException>(exception);
        }
        
        [Fact]
        public void WeightOccupationArea_EmployeeIsNull_WeightNotDefined()
        {
            // Arrange
            // Act
            var exception = Record.Exception(() => WeightOccupationArea.New(null));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<InvalidFieldException>(exception);
        }

        private Employee NewEmployee(string occupationArea)
        {
            var admissionDate = DateTime.Now.AddYears(-10);
            return Employee.New(
                EmployeeTest.RegistrationValid,
                EmployeeTest.NameValid,
                occupationArea,
                EmployeeTest.PositionValid,
                EmployeeTest.GrossSalaryValid,
                admissionDate);
        }
    }
}