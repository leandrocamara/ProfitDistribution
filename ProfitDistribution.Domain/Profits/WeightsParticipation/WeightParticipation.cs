using ProfitDistribution.Domain.Employees;

namespace ProfitDistribution.Domain.Profits.WeightsParticipation
{
    public abstract class WeightParticipation
    {
        protected const byte WeightOne = 1;
        protected const byte WeightTwo = 2;
        protected const byte WeightThree = 3;
        protected const byte WeightFive = 5;

        public byte Weight { get; protected set; }
        protected Employee Employee { get; }

        protected WeightParticipation(Employee employee)
        {
            Employee = employee;
            Validate();
        }

        protected abstract byte DefineWeight();

        private void Validate()
        {
            // TODO
        }
    }
}