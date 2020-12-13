using MediatR;
using ProfitDistribution.Application.Abstraction.Common;
using ProfitDistribution.Application.Abstraction.Profits.ViewModels;

namespace ProfitDistribution.Application.Abstraction.Profits.Queries
{
    public class GetProfitsDistributionQuery : IRequest<QueryResponse<GetProfitsDistributionViewModel>>
    {
        public int AmountAvailable { get; }

        public GetProfitsDistributionQuery(int amountAvailable)
        {
            AmountAvailable = amountAvailable;
        }
    }
}