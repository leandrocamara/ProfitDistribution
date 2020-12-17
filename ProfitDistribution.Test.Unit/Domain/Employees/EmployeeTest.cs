using System;
using ProfitDistribution.Domain.Employees;
using ProfitDistribution.Exception.DomainExceptions;
using Xunit;

namespace ProfitDistribution.Test.Unit.Domain.Employees
{
    public class EmployeeTest
    {
        public const string RegistrationValid = "000123";
        public const string NameValid = "João";
        public const string AreaValid = "Diretoria";
        public const string PositionValid = "Diretor";
        public const string GrossSalaryValid = "R$ 8.500,00";

        [Fact]
        public void Employee_AllParamsValid_EmployeeCreated()
        {
            // Arrange
            var admissionDate = DateTime.Now.AddYears(-10);

            // Act
            var employee = Employee.New(
                RegistrationValid, NameValid, AreaValid, PositionValid, GrossSalaryValid, admissionDate);

            // Assert
            Assert.NotNull(employee);
        }

        [Fact]
        public void Employee_AllParamsInvalid_EmployeeNotCreated()
        {
            // Arrange
            var admissionDate = DateTime.MinValue;

            // Act
            var exception = Record.Exception(() => Employee.New("", "", "", "", "", admissionDate));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<InvalidFieldException>(exception);
        }

        [Fact]
        public void Employee_AdmissionDateIsFourYearsAgo_AdmissionTimeIsFourYears()
        {
            // Arrange
            const int fourYears = 4;
            var admissionDate = DateTime.Now.AddYears(-fourYears);

            // Act
            var employee = Employee.New(
                RegistrationValid, NameValid, AreaValid, PositionValid, GrossSalaryValid, admissionDate);

            // Assert
            Assert.NotNull(employee);
            Assert.Equal(fourYears, (int) employee.AdmissionTimeInYears());
        }

        public static Employee NewEmployee()
        {
            var admissionDate = DateTime.Now.AddYears(-10);
            return Employee.New(
                RegistrationValid,
                NameValid,
                AreaValid,
                PositionValid,
                GrossSalaryValid,
                admissionDate);
        }
    }
}