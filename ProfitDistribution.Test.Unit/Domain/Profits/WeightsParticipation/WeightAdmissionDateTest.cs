using System;
using ProfitDistribution.Domain.Employees;
using ProfitDistribution.Domain.Profits.WeightsParticipation;
using ProfitDistribution.Exception.DomainExceptions;
using ProfitDistribution.Test.Unit.Domain.Employees;
using Xunit;

namespace ProfitDistribution.Test.Unit.Domain.Profits.WeightsParticipation
{
    public class WeightAdmissionDateTest
    {
        [Fact]
        public void WeightAdmissionDate_AdmissionTimeIsLessOneYear_WeightOneDefined()
        {
            // Arrange
            const int lessOneYear = 0;
            var admissionDate = DateTime.Now.AddYears(-lessOneYear);
            var employee = NewEmployee(admissionDate);

            // Act
            var weightAdmissionDate = WeightAdmissionDate.New(employee).Weight;

            // Assert
            Assert.Equal(WeightParticipation.WeightOne, weightAdmissionDate);
        }

        [Fact]
        public void WeightAdmissionDate_AdmissionTimeIsGreaterOneYearAndLessThreeYear_WeightTwoDefined()
        {
            // Arrange
            const int twoYears = 2;
            var admissionDate = DateTime.Now.AddYears(-twoYears);
            var employee = NewEmployee(admissionDate);

            // Act
            var weightAdmissionDate = WeightAdmissionDate.New(employee).Weight;

            // Assert
            Assert.Equal(WeightParticipation.WeightTwo, weightAdmissionDate);
        }

        [Fact]
        public void WeightAdmissionDate_AdmissionTimeIsGreaterThreeYearAndLessEightYear_WeightThreeDefined()
        {
            // Arrange
            const int fourYears = 4;
            var admissionDate = DateTime.Now.AddYears(-fourYears);
            var employee = NewEmployee(admissionDate);

            // Act
            var weightAdmissionDate = WeightAdmissionDate.New(employee).Weight;

            // Assert
            Assert.Equal(WeightParticipation.WeightThree, weightAdmissionDate);
        }

        [Fact]
        public void WeightAdmissionDate_AdmissionTimeIsGreaterEightYear_WeightFiveDefined()
        {
            // Arrange
            const int tenYears = 10;
            var admissionDate = DateTime.Now.AddYears(-tenYears);
            var employee = NewEmployee(admissionDate);

            // Act
            var weightAdmissionDate = WeightAdmissionDate.New(employee).Weight;

            // Assert
            Assert.Equal(WeightParticipation.WeightFive, weightAdmissionDate);
        }

        [Fact]
        public void WeightAdmissionDate_EmployeeIsNull_WeightNotDefined()
        {
            // Arrange
            // Act
            var exception = Record.Exception(() => WeightAdmissionDate.New(null));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<InvalidFieldException>(exception);
        }

        private Employee NewEmployee(DateTime admissionDate)
        {
            return Employee.New(
                EmployeeTest.RegistrationValid,
                EmployeeTest.NameValid,
                EmployeeTest.AreaValid,
                EmployeeTest.PositionValid,
                EmployeeTest.GrossSalaryValid,
                admissionDate);
        }
    }
}