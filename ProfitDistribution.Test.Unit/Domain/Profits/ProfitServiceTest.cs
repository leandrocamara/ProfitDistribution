using System.Collections.Generic;
using Moq;
using ProfitDistribution.Domain.Employees;
using ProfitDistribution.Domain.Employees.Interfaces;
using ProfitDistribution.Domain.Profits;
using ProfitDistribution.Domain.ValueObjects;
using Xunit;

namespace ProfitDistribution.Test.Unit.Domain.Profits
{
    public class ProfitServiceTest
    {
        private readonly ProfitService _profitService;
        private readonly Mock<IEmployeeRepository> _employeeRepositoryMock;

        public ProfitServiceTest()
        {
            _employeeRepositoryMock = new Mock<IEmployeeRepository>();
            _profitService = new ProfitService(_employeeRepositoryMock.Object);
        }

        [Fact]
        public async void ProfitDistribution_AmountAvailableIsSufficient_ProfitDistributed()
        {
            // Arrange
            var employees = new List<Employee>();
            _employeeRepositoryMock.Setup(er => er.GetAll()).ReturnsAsync(employees);

            var amountAvailable = new Money(2150350);

            // Act
            var exception = await Record.ExceptionAsync(() => _profitService.GetProfitDistribution(amountAvailable));

            // Assert
            Assert.Null(exception);
        }
    }
}