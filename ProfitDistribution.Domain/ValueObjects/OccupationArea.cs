namespace ProfitDistribution.Domain.ValueObjects
{
    public struct OccupationArea
    {
        public const string BoardDirectors = "Diretoria";
        public const string Accounting = "Contabilidade";
        public const string Financial = "Financeiro";
        public const string Technology = "Tecnologia";
        public const string GeneralServices = "Serviços Gerais";
        public const string CustomerRelationship = "Relacionamento com o Cliente";

        private readonly string _value;

        public OccupationArea(string value)
        {
            _value = value;
        }

        public bool IsBoardDirectors() => Equals(BoardDirectors);
        public bool IsAccounting() => Equals(Accounting);
        public bool IsFinancial() => Equals(Financial);
        public bool IsTechnology() => Equals(Technology);
        public bool IsGeneralServices() => Equals(GeneralServices);
        public bool IsCustomerRelationship() => Equals(CustomerRelationship);

        public override string ToString()
        {
            return _value;
        }

        public bool Equals(string value)
        {
            return _value.Equals(value);
        }
    }
}