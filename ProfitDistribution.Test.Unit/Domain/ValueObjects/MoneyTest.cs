using ProfitDistribution.Domain.ValueObjects;
using ProfitDistribution.Exception.DomainExceptions;
using Xunit;

namespace ProfitDistribution.Test.Unit.Domain.ValueObjects
{
    public class MoneyTest
    {
        [Fact]
        public void Money_ValueValid_MoneyCreated()
        {
            // Arrange
            const double value = 8500.50;
            const string valueCurrencyFormatOne = "R$ 8.500,50";
            const string valueCurrencyFormatTwo = "R$ 8500,50";
            const string valueCurrencyFormatThree = "8500,50";

            // Act
            var moneyFormatOne = new Money(valueCurrencyFormatOne);
            var moneyFormatTwo = new Money(valueCurrencyFormatTwo);
            var moneyFormatThree = new Money(valueCurrencyFormatThree);

            // Assert
            Assert.Equal(value, moneyFormatOne.ToDouble());
            Assert.Equal(value, moneyFormatTwo.ToDouble());
            Assert.Equal(value, moneyFormatThree.ToDouble());
        }

        [Fact]
        public void Money_ValueInvalid_MoneyNotCreated()
        {
            // Arrange
            const string valueCurrency = "8,500,50";

            // Act
            var exception = Record.Exception(() => new Money(valueCurrency));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<InvalidFieldException>(exception);
        }

        [Fact]
        public void Money_ValueIsThreeMinimumSalaryWage_MinimumSalaryWageIsThree()
        {
            // Arrange
            const double amountMinimumWages = 3;
            const double value = Money.MinimumSalaryWage * amountMinimumWages;
            var valueCurrency = value.ToString("C");

            // Act
            var money = new Money(valueCurrency);

            // Assert
            Assert.Equal(amountMinimumWages, money.AmountMinimumWages());
        }

        [Fact]
        public void Money_ValueIsLessZero_MoneyNegative()
        {
            // Arrange
            const double value = -5000.50;

            // Act
            var money = new Money(value);

            // Assert
            Assert.True(money.IsNegative());
        }
    }
}