using ProfitDistribution.Domain.Employees;

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
            throw new System.NotImplementedException();
        }

        private WeightOccupationArea(Employee employee) : base(employee)
        {
        }
    }
}