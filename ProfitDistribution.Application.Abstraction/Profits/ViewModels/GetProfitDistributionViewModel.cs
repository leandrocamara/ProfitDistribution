using System.Collections.Generic;

namespace ProfitDistribution.Application.Abstraction.Profits.ViewModels
{
    public class GetProfitDistributionViewModel
    {
        public int TotalEmployees { get; }
        public string TotalDistributed { get; }
        public string TotalAvailable { get; }
        public string TotalBalanceAvailable { get; }
        public List<string> Participations { get; }

        public GetProfitDistributionViewModel(
            int totalEmployees,
            string totalDistributed,
            string totalAvailable,
            string totalBalanceAvailable,
            List<string> participations)
        {
            Participations = participations;
            TotalEmployees = totalEmployees;
            TotalDistributed = totalDistributed;
            TotalAvailable = totalAvailable;
            TotalBalanceAvailable = totalBalanceAvailable;
        }
    }
}