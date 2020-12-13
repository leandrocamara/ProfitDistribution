using System.Collections.Generic;

namespace ProfitDistribution.Application.Abstraction.Profits.ViewModels
{
    public class GetProfitsDistributionViewModel
    {
        public List<string> Participations { get; } // List<EmployeeParticipation>
        public int TotalEmployees { get; }
        public int TotalDistributed { get; }
        public int TotalAvailable { get; }
        public int TotalBalanceAvailable { get; }

        public GetProfitsDistributionViewModel(
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