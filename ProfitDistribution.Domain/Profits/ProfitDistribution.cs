using System.Collections.Generic;
using ProfitDistribution.Domain.Employees;

namespace ProfitDistribution.Domain.Profits
{
    public class ProfitDistribution
    {
        public int TotalEmployees { get; protected set; }
        public int TotalDistributed { get; protected set; }
        public int TotalAvailable { get; protected set; }
        public int TotalBalanceAvailable { get; protected set; }
        public List<EmployeeProfitDistribution> Participations { get; protected set; }

        public static ProfitDistribution New(double amountAvailable, List<Employee> employees)
        {
            var profitDistribution = new ProfitDistribution
            {
                TotalEmployees = 0,
                TotalDistributed = 0,
                TotalAvailable = 0,
                TotalBalanceAvailable = 0,
                Participations = new List<EmployeeProfitDistribution>()
            };

            profitDistribution.Validate();

            return profitDistribution;
        }

        private void Validate()
        {
        }

        private ProfitDistribution()
        {
        }
    }
}