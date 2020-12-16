using System.Collections.Generic;
using System.Linq;
using ProfitDistribution.Domain.Employees;
using ProfitDistribution.Domain.ValueObjects;

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
            var totalDistributed = Participations.Sum(p => p.ParticipationValue);
            var totalBalanceAvailable = TotalAvailable.ToDouble() - totalDistributed;

            TotalDistributed = new Money(totalDistributed);
            TotalBalanceAvailable = new Money(totalBalanceAvailable);
        }

        private void Validate()
        {
            // TODO
        }

        private ProfitDistribution()
        {
            TotalDistributed = new Money(0);
            TotalBalanceAvailable = new Money(0);
        }
    }
}