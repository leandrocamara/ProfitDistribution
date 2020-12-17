using ProfitDistribution.Domain.Employees;
using ProfitDistribution.Exception.DomainExceptions;
using ProfitDistribution.Shared;

namespace ProfitDistribution.Domain.Profits.WeightsParticipation
{
    public abstract class WeightParticipation
    {
        public const byte WeightOne = 1;
        public const byte WeightTwo = 2;
        public const byte WeightThree = 3;
        public const byte WeightFive = 5;

        public byte Weight { get; protected set; }
        protected Employee Employee { get; }

        protected WeightParticipation(Employee employee)
        {
            Employee = employee;
            Validate();
        }

        protected abstract void DefineWeight();

        private void Validate()
        {
            if (Employee == null)
                throw new InvalidFieldException(Messages.Format(Messages.RequiredProperty, nameof(Employee)));
        }
    }
}