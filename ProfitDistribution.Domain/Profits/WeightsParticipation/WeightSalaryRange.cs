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

        protected override void DefineWeight()
        {
            var amountMinimumWages = Employee.GrossMoney.AmountMinimumWages();

            if (Employee.Position.IsIntern() || amountMinimumWages <= ThreeMinimumWages)
                Weight = WeightOne;
            else if (amountMinimumWages > ThreeMinimumWages && amountMinimumWages <= FiveMinimumWages)
                Weight = WeightTwo;
            else if (amountMinimumWages > FiveMinimumWages && amountMinimumWages <= EightMinimumWages)
                Weight = WeightThree;
            else
                Weight = WeightFive;
        }

        private WeightSalaryRange(Employee employee) : base(employee)
        {
        }
    }
}