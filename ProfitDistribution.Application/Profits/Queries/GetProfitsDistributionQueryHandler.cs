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
    public class GetProfitsDistributionQueryHandler : Query<GetProfitsDistributionViewModel>,
        IRequestHandler<GetProfitsDistributionQuery, QueryResponse<GetProfitsDistributionViewModel>>
    {
        public async Task<QueryResponse<GetProfitsDistributionViewModel>> Handle(
            GetProfitsDistributionQuery query, CancellationToken _)
        {
            try
            {
                return QueryResponseOk(new GetProfitsDistributionViewModel(new List<string>(), 0, 0, 0, 0));
            }
            catch (BaseException e)
            {
                return QueryResponseFail(e);
            }
        }
    }
}