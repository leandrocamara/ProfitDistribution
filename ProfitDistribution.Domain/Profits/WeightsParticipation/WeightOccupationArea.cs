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

        protected override void DefineWeight()
        {
            var area = Employee.Area;

            if (area.IsBoardDirectors())
                Weight = WeightOne;
            else if (area.IsAccounting() || area.IsFinancial() || area.IsTechnology())
                Weight = WeightTwo;
            else if (area.IsGeneralServices())
                Weight = WeightThree;
            else if (area.IsCustomerRelationship())
                Weight = WeightFive;
            else
            {
                throw new DomainException(Messages.Format(
                    Messages.OccupationAreaNotIncludedDistributionProfits, area.ToString()));
            }
        }

        private WeightOccupationArea(Employee employee) : base(employee)
        {
        }
    }
}