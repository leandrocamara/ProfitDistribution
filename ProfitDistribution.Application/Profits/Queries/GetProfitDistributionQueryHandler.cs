using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProfitDistribution.Application.Abstraction.Common;
using ProfitDistribution.Application.Abstraction.Profits.Queries;
using ProfitDistribution.Application.Abstraction.Profits.ViewModels;
using ProfitDistribution.Application.Common;
using ProfitDistribution.Domain.Profits.Interfaces;
using ProfitDistribution.Domain.ValueObjects;
using ProfitDistribution.Exception;

namespace ProfitDistribution.Application.Profits.Queries
{
    public class GetProfitDistributionQueryHandler : Query<GetProfitDistributionViewModel>,
        IRequestHandler<GetProfitDistributionQuery, QueryResponse<GetProfitDistributionViewModel>>
    {
        private readonly IProfitService _profitService;

        public GetProfitDistributionQueryHandler(IProfitService profitService)
        {
            _profitService = profitService;
        }

        public async Task<QueryResponse<GetProfitDistributionViewModel>> Handle(
            GetProfitDistributionQuery query, CancellationToken _)
        {
            try
            {
                var amountAvailableMoney = new Money(query.AmountAvailable);
                var profitDistribution = await _profitService.GetProfitDistribution(amountAvailableMoney);

                return QueryResponseOk(new GetProfitDistributionViewModel(
                    profitDistribution.TotalEmployees,
                    profitDistribution.TotalDistributed.ToCurrency(),
                    profitDistribution.TotalAvailable.ToCurrency(),
                    profitDistribution.TotalBalanceAvailable.ToCurrency(),
                    profitDistribution.Participations.Select(p => p.Employee.Name).ToList()));
            }
            catch (BaseException e)
            {
                return QueryResponseFail(e);
            }
        }
    }
}