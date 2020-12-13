using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProfitDistribution.Application.Abstraction.Common;
using ProfitDistribution.Application.Abstraction.Profits.Queries;
using ProfitDistribution.Application.Abstraction.Profits.ViewModels;
using ProfitDistribution.Application.Common;
using ProfitDistribution.Exception;

namespace ProfitDistribution.Application.Profits.Queries
{
    public class GetProfitDistributionQueryHandler : Query<GetProfitDistributionViewModel>,
        IRequestHandler<GetProfitDistributionQuery, QueryResponse<GetProfitDistributionViewModel>>
    {
        public async Task<QueryResponse<GetProfitDistributionViewModel>> Handle(
            GetProfitDistributionQuery query, CancellationToken _)
        {
            try
            {
                return QueryResponseOk(new GetProfitDistributionViewModel(new List<string>(), 0, 0, 0, 0));
            }
            catch (BaseException e)
            {
                return QueryResponseFail(e);
            }
        }
    }
}