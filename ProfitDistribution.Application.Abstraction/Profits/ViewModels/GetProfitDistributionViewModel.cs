using System.Collections.Generic;

namespace ProfitDistribution.Application.Abstraction.Profits.ViewModels
{
    public class GetProfitDistributionViewModel
    {
        public int TotalEmployees { get; }
        public double TotalDistributed { get; }
        public double TotalAvailable { get; }
        public double TotalBalanceAvailable { get; }
        public List<string> Participations { get; }

        public GetProfitDistributionViewModel(
            int totalEmployees,
            double totalDistributed,
            double totalAvailable,
            double totalBalanceAvailable,
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