using System.Collections.Generic;
using System.Linq;

namespace ProfitDistribution.Domain.ValueObjects
{
    public struct OccupationArea
    {
        public const int BoardDirectors = 1;
        public const int Accounting = 2;
        public const int Financial = 3;
        public const int Technology = 4;
        public const int GeneralServices = 5;
        public const int CustomerRelationship = 6;

        private readonly int _value;
        private readonly Dictionary<int, string> _occupationAreas;

        public OccupationArea(string value) : this()
        {
            _occupationAreas = new Dictionary<int, string>
            {
                {BoardDirectors, "Diretoria"},
                {Accounting, "Contabilidade"},
                {Financial, "Financeiro"},
                {Technology, "Tecnologia"},
                {GeneralServices, "Serviços Gerais"},
                {CustomerRelationship, "Relacionamento com o Cliente"}
            };
            _value = GetKeyByValue(value);
        }

        public bool IsBoardDirectors() => Equals(BoardDirectors);
        public bool IsAccounting() => Equals(Accounting);
        public bool IsFinancial() => Equals(Financial);
        public bool IsTechnology() => Equals(Technology);
        public bool IsGeneralServices() => Equals(GeneralServices);
        public bool IsCustomerRelationship() => Equals(CustomerRelationship);

        public int ToInt()
        {
            return _value;
        }

        public override string ToString()
        {
            return _occupationAreas.GetValueOrDefault(_value);
        }

        public bool Equals(string description)
        {
            return ToString().Equals(description);
        }

        public bool Equals(int value)
        {
            return _value.Equals(value);
        }

        public bool Equals(OccupationArea area)
        {
            return Equals(area.ToInt());
        }

        private int GetKeyByValue(string value)
        {
            return _occupationAreas
                .FirstOrDefault(a => a.Value.ToLower().Contains(value.ToLower())).Key;
        }
    }
}