using System.Collections.Generic;

namespace ProfitDistribution.Application.Abstraction.Profits.ViewModels
{
    public class GetProfitDistributionViewModel
    {
        public int TotalEmployees { get; }
        public int TotalDistributed { get; }
        public int TotalAvailable { get; }
        public int TotalBalanceAvailable { get; }
        public List<string> Participations { get; } // List<EmployeeProfitDistribution>

        public GetProfitDistributionViewModel(
            List<string> participations,
            int totalEmployees,
            int totalDistributed,
            int totalAvailable,
            int totalBalanceAvailable)
        {
            Participations = participations;
            TotalEmployees = totalEmployees;
            TotalDistributed = totalDistributed;
            TotalAvailable = totalAvailable;
            TotalBalanceAvailable = totalBalanceAvailable;
        }
    }
}