using System.Collections.Generic;
using System.Linq;
using ProfitDistribution.Domain.Employees;

namespace ProfitDistribution.Domain.Profits
{
    public class ProfitDistribution
    {
        public int TotalEmployees { get; protected set; }
        public double TotalDistributed { get; protected set; }
        public double TotalAvailable { get; protected set; }
        public double TotalBalanceAvailable { get; protected set; }
        public List<ProfitDistributionEmployee> Participations { get; protected set; }

        public static ProfitDistribution New(List<Employee> employees, double amountAvailable)
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
            TotalDistributed = Participations.Sum(p => p.ParticipationValue);
            TotalBalanceAvailable = TotalDistributed - TotalAvailable;
        }

        private void Validate()
        {
            // TODO
        }

        private ProfitDistribution()
        {
            TotalDistributed = 0;
            TotalBalanceAvailable = 0;
        }
    }
}