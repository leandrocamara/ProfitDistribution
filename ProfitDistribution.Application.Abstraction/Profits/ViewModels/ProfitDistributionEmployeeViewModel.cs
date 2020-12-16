namespace ProfitDistribution.Application.Abstraction.Profits.ViewModels
{
    public class ProfitDistributionEmployeeViewModel
    {
        public string Registration { get; }
        public string Name { get; }
        public string ParticipationValue { get; }

        public ProfitDistributionEmployeeViewModel(string registration, string name, string participationValue)
        {
            Name = name;
            Registration = registration;
            ParticipationValue = participationValue;
        }
    }
}