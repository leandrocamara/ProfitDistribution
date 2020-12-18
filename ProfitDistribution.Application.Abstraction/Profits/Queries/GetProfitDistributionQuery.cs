using MediatR;
using ProfitDistribution.Application.Abstraction.Common;
using ProfitDistribution.Application.Abstraction.Profits.ViewModels;

namespace ProfitDistribution.Application.Abstraction.Profits.Queries
{
    public class GetProfitDistributionQuery : IRequest<QueryResponse<ProfitDistributionViewModel>>
    {
        public string AmountAvailable { get; }

        public GetProfitDistributionQuery(string amountAvailable)
        {
            AmountAvailable = amountAvailable;
        }
    }
}