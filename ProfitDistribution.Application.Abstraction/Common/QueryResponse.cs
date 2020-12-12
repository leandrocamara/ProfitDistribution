using ProfitDistribution.Application.Abstraction.Common.Interfaces;
using ProfitDistribution.Exception;

namespace ProfitDistribution.Application.Abstraction.Common
{
    public class QueryResponse<TData> : IResponse<TData>
    {
        public TData Data { get; private set; }

        public bool Success { get; private set; }

        public virtual BaseException Exception { get; private set; }

        public QueryResponse(TData data)
        {
            Data = data;
            Success = true;
        }

        public QueryResponse(BaseException ex)
        {
            Success = false;
            Exception = ex;
        }
    }
}