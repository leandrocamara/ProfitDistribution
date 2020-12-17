using Moq;
using ProfitDistribution.Domain.Employees.Interfaces;
using ProfitDistribution.Domain.Profits;
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
        public void ProfitDistribution_AmountAvailableIsSufficient_ProfitDistributed()
        {
            // Arrange
            // Act
            // Assert
        }
    }
}