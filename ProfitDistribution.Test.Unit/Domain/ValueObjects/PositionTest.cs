using ProfitDistribution.Domain.ValueObjects;
using Xunit;

namespace ProfitDistribution.Test.Unit.Domain.ValueObjects
{
    public class PositionTest
    {
        [Fact]
        public void Position_ValueValid_PositionCreated()
        {
            // Arrange
            const string value = "Diretor";

            // Act
            var position = new Position(value);

            // Assert
            Assert.Equal(value, position.ToString());
        }

        [Fact]
        public void Position_ValueIsIntern_PositionIsIntern()
        {
            // Arrange
            const string value = Position.Intern;

            // Act
            var position = new Position(value);

            // Assert
            Assert.True(position.IsIntern());
        }
    }
}