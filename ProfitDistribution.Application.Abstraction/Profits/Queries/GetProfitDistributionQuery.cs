using MediatR;
using ProfitDistribution.Application.Abstraction.Common;
using ProfitDistribution.Application.Abstraction.Profits.ViewModels;

namespace ProfitDistribution.Application.Abstraction.Profits.Queries
{
    public class GetProfitDistributionQuery : IRequest<QueryResponse<GetProfitDistributionViewModel>>
    {
        public double AmountAvailable { get; }

        public GetProfitDistributionQuery(double amountAvailable)
        {
            AmountAvailable = amountAvailable;
        }
    }
}