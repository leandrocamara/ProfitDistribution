using ProfitDistribution.Domain.Employees;

namespace ProfitDistribution.Domain.Profits.WeightsParticipation
{
    public class WeightSalaryRange : WeightParticipation
    {
        public static WeightSalaryRange New(Employee employee)
        {
            var weight = new WeightSalaryRange(employee);

            weight.DefineWeight();

            return weight;
        }

        protected override byte DefineWeight()
        {
            throw new System.NotImplementedException();
        }

        private WeightSalaryRange(Employee employee) : base(employee)
        {
        }
    }
}