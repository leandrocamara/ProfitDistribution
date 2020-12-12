using ProfitDistribution.Application.Abstraction.Common;
using ProfitDistribution.Exception;

namespace ProfitDistribution.Application.Common
{
    public abstract class Query<TData>
    {
        protected Query()
        {
        }

        protected QueryResponse<TData> QueryResponseOk(TData data)
        {
            return new QueryResponse<TData>(data);
        }

        public QueryResponse<TData> QueryResponseFail(BaseException exception)
        {
            return new QueryResponse<TData>(exception);
        }
    }
}