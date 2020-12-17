using System;
using System.Globalization;
using System.Text.RegularExpressions;
using ProfitDistribution.Exception.DomainExceptions;
using ProfitDistribution.Shared;

namespace ProfitDistribution.Domain.ValueObjects
{
    public struct Money
    {
        public const double MinimumSalaryWage = 1045.00;

        private readonly double _value;

        public Money(double value)
        {
            _value = value;
        }

        public Money(string value)
        {
            var valueCleaned = ValueCleaned(value);

            if (!double.TryParse(valueCleaned, out var valueParsed))
                throw new InvalidFieldException(Messages.InvalidMoney);

            _value = valueParsed;
        }

        public double AmountMinimumWages()
        {
            return Math.Round(_value / MinimumSalaryWage, 2);
        }

        public double ToDouble()
        {
            return Math.Round(_value, 2);
        }

        public string ToCurrency()
        {
            return ToDouble().ToString("C2", CultureInfo.CreateSpecificCulture("pt-BR"));
        }

        public bool IsNegative()
        {
            return _value < 0;
        }

        private static string ValueCleaned(string value)
        {
            var valueCleaned = Regex.Replace(value, @"[^\d+,\d+]", "");
            return valueCleaned.Replace(",", ".");
        }
    }
}