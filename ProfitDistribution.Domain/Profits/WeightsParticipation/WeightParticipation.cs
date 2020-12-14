using ProfitDistribution.Domain.Employees;

namespace ProfitDistribution.Domain.Profits.WeightsParticipation
{
    public abstract class WeightParticipation
    {
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