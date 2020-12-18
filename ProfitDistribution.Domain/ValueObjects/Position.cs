namespace ProfitDistribution.Domain.ValueObjects
{
    public struct Position
    {
        public const string Intern = "Estagiário";

        private readonly string _value;

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