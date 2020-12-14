using ProfitDistribution.Domain.Employees;

namespace ProfitDistribution.Domain.Profits.WeightsParticipation
{
    public class WeightSalaryRange : WeightParticipation
    {
        private const byte ThreeMinimumWages = 3;
        private const byte FiveMinimumWages = 5;
        private const byte EightMinimumWages = 8;

        public static WeightSalaryRange New(Employee employee)
        {
            var weight = new WeightSalaryRange(employee);

            weight.DefineWeight();

            return weight;
        }

        protected override byte DefineWeight()
        {
            var amountMinimumWages = Employee.GrossSalary.AmountMinimumWages();

            if (Employee.Position.IsIntern() || amountMinimumWages <= ThreeMinimumWages)
                return WeightOne;
            if (amountMinimumWages > ThreeMinimumWages && amountMinimumWages <= FiveMinimumWages)
                return WeightTwo;
            if (amountMinimumWages > FiveMinimumWages && amountMinimumWages <= EightMinimumWages)
                return WeightThree;

            return WeightFive;
        }

        private WeightSalaryRange(Employee employee) : base(employee)
        {
        }
    }
}