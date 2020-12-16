using System.Collections.Generic;
using System.Linq;
using ProfitDistribution.Domain.Employees;
using ProfitDistribution.Domain.ValueObjects;
using ProfitDistribution.Exception.DomainExceptions;
using ProfitDistribution.Shared;

namespace ProfitDistribution.Domain.Profits
{
    public class ProfitDistribution
    {
        public int TotalEmployees { get; protected set; }
        public Money TotalDistributed { get; protected set; }
        public Money TotalAvailable { get; protected set; }
        public Money TotalBalanceAvailable { get; protected set; }
        public List<ProfitDistributionEmployee> Participations { get; protected set; }

        public static ProfitDistribution New(IList<Employee> employees, Money amountAvailable)
        {
            var profitDistribution = new ProfitDistribution
            {
                TotalEmployees = employees.Count,
                TotalAvailable = amountAvailable,
                Participations = employees.Select(ProfitDistributionEmployee.New).ToList()
            };

            profitDistribution.Validate();
            profitDistribution.CalculateTotalDistributed();

            return profitDistribution;
        }

        private void CalculateTotalDistributed()
        {
            var totalDistributed = Participations.Sum(p => p.ParticipationValue.ToDouble());
            var totalBalanceAvailable = TotalAvailable.ToDouble() - totalDistributed;

            TotalDistributed = new Money(totalDistributed);
            TotalBalanceAvailable = new Money(totalBalanceAvailable);

            if (TotalBalanceAvailable.IsNegative())
            {
                throw new DomainException(Messages.Format(Messages.InsufficientAmountAvailable,
                    new object[] {TotalDistributed.ToCurrency(), TotalBalanceAvailable.ToCurrency()}));
            }
        }

        private void Validate()
        {
            if (TotalAvailable.IsNegative())
                throw new InvalidFieldException(Messages.Format(Messages.InvalidValue, nameof(TotalAvailable)));
        }

        private ProfitDistribution()
        {
            TotalDistributed = new Money(0);
            TotalBalanceAvailable = new Money(0);
        }
    }
}