using Xunit;

namespace ProfitDistribution.Test.Unit.Domain.Profits.WeightsParticipation
{
    public class WeightSalaryRangeTest
    {
        [Fact]
        public void WeightSalaryRange_PositionIsInternOrGrossMoneyIsLessThreeMinimumWages_WeightOneDefined()
        {
            // Arrange
            // Act
            // Assert
        }

        [Fact]
        public void WeightSalaryRange_GrossMoneyIsGreaterThreeMinimumWagesAndLessFiveMinimumWages_WeightTwoDefined()
        {
            // Arrange
            // Act
            // Assert
        }

        [Fact]
        public void WeightSalaryRange_GrossMoneyIsGreaterFiveMinimumWagesAndLessEightMinimumWages_WeightThreeDefined()
        {
            // Arrange
            // Act
            // Assert
        }

        [Fact]
        public void WeightSalaryRange_GrossMoneyIsGreaterEightMinimumWages_WeightFiveDefined()
        {
            // Arrange
            // Act
            // Assert
        }

        [Fact]
        public void WeightSalaryRange_EmployeeIsNull_WeightNotDefined()
        {
            // Arrange
            // Act
            // Assert
        }
    }
}