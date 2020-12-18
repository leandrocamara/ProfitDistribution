using System.Collections.Generic;

namespace ProfitDistribution.Application.Abstraction.Profits.ViewModels
{
    public class ProfitDistributionViewModel
    {
        public int TotalEmployees { get; }
        public string TotalDistributed { get; }
        public string TotalAvailable { get; }
        public string TotalBalanceAvailable { get; }
        public List<ProfitDistributionEmployeeViewModel> Participations { get; }

        public ProfitDistributionViewModel(
            int totalEmployees,
            string totalDistributed,
            string totalAvailable,
            string totalBalanceAvailable,
            List<ProfitDistributionEmployeeViewModel> participations)
        {
            Participations = participations;
            TotalEmployees = totalEmployees;
            TotalDistributed = totalDistributed;
            TotalAvailable = totalAvailable;
            TotalBalanceAvailable = totalBalanceAvailable;
        }
    }
}