using Xunit;

namespace ProfitDistribution.Test.Unit.Domain.Profits.WeightsParticipation
{
    public class WeightAdmissionDateTest
    {
        [Fact]
        public void WeightAdmissionDate_AdmissionTimeIsLessOneYear_WeightOneDefined()
        {
            // Arrange
            // Act
            // Assert
        }

        [Fact]
        public void WeightAdmissionDate_AdmissionTimeIsGreaterOneYearAndLessThreeYear_WeightTwoDefined()
        {
            // Arrange
            // Act
            // Assert
        }

        [Fact]
        public void WeightAdmissionDate_AdmissionTimeIsGreaterThreeYearAndLessEightYear_WeightThreeDefined()
        {
            // Arrange
            // Act
            // Assert
        }

        [Fact]
        public void WeightAdmissionDate_AdmissionTimeIsGreaterEightYear_WeightFiveDefined()
        {
            // Arrange
            // Act
            // Assert
        }

        [Fact]
        public void WeightAdmissionDate_EmployeeIsNull_WeightNotDefined()
        {
            // Arrange
            // Act
            // Assert
        }
    }
}