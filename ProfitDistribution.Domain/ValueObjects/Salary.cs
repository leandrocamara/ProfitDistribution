namespace ProfitDistribution.Domain.ValueObjects
{
    public struct Salary
    {
        private readonly double _value;
        private const double MinimumWage = 1045.00;

        public Salary(double value)
        {
            _value = value;
        }

        public double AmountMinimumWages()
        {
            return _value / MinimumWage;
        }

        public double ToDouble()
        {
            return _value;
        }
    }
}