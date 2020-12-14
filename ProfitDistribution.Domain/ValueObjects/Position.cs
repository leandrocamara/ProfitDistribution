namespace ProfitDistribution.Domain.ValueObjects
{
    public struct Position
    {
        private readonly string _value;
        private const string Intern = "Estagiário";

        public Position(string value)
        {
            _value = value;
        }

        public bool IsIntern()
        {
            return _value.Equals(Intern);
        }

        public override string ToString()
        {
            return _value;
        }
    }
}