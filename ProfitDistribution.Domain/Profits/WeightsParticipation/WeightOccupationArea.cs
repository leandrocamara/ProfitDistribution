using ProfitDistribution.Domain.Employees;
using ProfitDistribution.Exception.DomainExceptions;
using ProfitDistribution.Shared;

namespace ProfitDistribution.Domain.Profits.WeightsParticipation
{
    public class WeightOccupationArea : WeightParticipation
    {
        public static WeightOccupationArea New(Employee employee)
        {
            var weight = new WeightOccupationArea(employee);

            weight.DefineWeight();

            return weight;
        }

        protected override byte DefineWeight()
        {
            var area = Employee.Area;

            if (area.IsBoardDirectors())
                return WeightOne;
            if (area.IsAccounting() || area.IsFinancial() || area.IsTechnology())
                return WeightTwo;
            if (area.IsGeneralServices())
                return WeightThree;
            if (area.IsCustomerRelationship())
                return WeightFive;

            throw new DomainException(Messages.OccupationAreaNotIncludedDistributionProfits(area.ToString()));
        }

        private WeightOccupationArea(Employee employee) : base(employee)
        {
        }
    }
}