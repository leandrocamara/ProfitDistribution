using ProfitDistribution.Domain.Employees;

namespace ProfitDistribution.Domain.Profits.WeightsParticipation
{
    public class WeightAdmissionDate : WeightParticipation
    {
        public static WeightAdmissionDate New(Employee employee)
        {
            var weight = new WeightAdmissionDate(employee);

            weight.DefineWeight();

            return weight;
        }

        protected override byte DefineWeight()
        {
            throw new System.NotImplementedException();
        }

        private WeightAdmissionDate(Employee employee) : base(employee)
        {
        }
    }
}