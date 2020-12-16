using System;
using System.Globalization;
using System.Text.RegularExpressions;
using ProfitDistribution.Exception.DomainExceptions;
using ProfitDistribution.Shared;

namespace ProfitDistribution.Domain.ValueObjects
{
    public struct Money
    {
        private readonly double _value;
        private const double MinimumSalaryWage = 1045.00;

        public Money(double value)
        {
            _value = value;
        }

        public Money(string value)
        {
            var valueCleaned = ValueCleaned(value);

            if (!double.TryParse(valueCleaned, out var valueParsed))
                throw new InvalidFieldException(Messages.Format(Messages.InvalidValue, value));

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

        private static string ValueCleaned(string value)
        {
            var valueCleaned = Regex.Replace(value, @"[^\d+,\d+]", "");
            return valueCleaned.Replace(",", ".");
        }
    }
}