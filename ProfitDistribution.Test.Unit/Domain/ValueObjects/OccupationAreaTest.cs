using ProfitDistribution.Domain.ValueObjects;
using Xunit;

namespace ProfitDistribution.Test.Unit.Domain.ValueObjects
{
    public class OccupationAreaTest
    {
        [Fact]
        public void OccupationArea_ValueValid_OccupationAreaCreated()
        {
            // Arrange
            const string value = "Segurança";

            // Act
            var occupationArea = new OccupationArea(value);

            // Assert
            Assert.Equal(value, occupationArea.ToString());
        }

        [Fact]
        public void OccupationArea_ValueIsBoardDirectors_OccupationAreaIsBoardDirectors()
        {
            // Arrange
            const string value = OccupationArea.BoardDirectors;

            // Act
            var occupationArea = new OccupationArea(value);

            // Assert
            Assert.True(occupationArea.IsBoardDirectors());
        }

        [Fact]
        public void Accounting_ValueIsAccounting_OccupationAreaIsAccounting()
        {
            // Arrange
            const string value = OccupationArea.Accounting;

            // Act
            var occupationArea = new OccupationArea(value);

            // Assert
            Assert.True(occupationArea.IsAccounting());
        }

        [Fact]
        public void Accounting_ValueIsFinancial_OccupationAreaIsFinancial()
        {
            // Arrange
            const string value = OccupationArea.Financial;

            // Act
            var occupationArea = new OccupationArea(value);

            // Assert
            Assert.True(occupationArea.IsFinancial());
        }

        [Fact]
        public void Accounting_ValueIsTechnology_OccupationAreaIsTechnology()
        {
            // Arrange
            const string value = OccupationArea.Technology;

            // Act
            var occupationArea = new OccupationArea(value);

            // Assert
            Assert.True(occupationArea.IsTechnology());
        }

        [Fact]
        public void Accounting_ValueIsGeneralServices_OccupationAreaIsGeneralServices()
        {
            // Arrange
            const string value = OccupationArea.GeneralServices;

            // Act
            var occupationArea = new OccupationArea(value);

            // Assert
            Assert.True(occupationArea.IsGeneralServices());
        }

        [Fact]
        public void Accounting_ValueIsCustomerRelationship_OccupationAreaIsCustomerRelationship()
        {
            // Arrange
            const string value = OccupationArea.CustomerRelationship;

            // Act
            var occupationArea = new OccupationArea(value);

            // Assert
            Assert.True(occupationArea.IsCustomerRelationship());
        }
    }
}