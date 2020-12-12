using ProfitDistribution.Application.Abstraction.Common.Interfaces;
using ProfitDistribution.Exception;

namespace ProfitDistribution.Application.Abstraction.Common
{
    public class CommandResponse : IResponse
    {
        public bool Success { get; private set; }

        public virtual BaseException Exception { get; private set; }

        public CommandResponse()
        {
            Success = true;
        }

        public CommandResponse(BaseException ex)
        {
            Success = false;
            Exception = ex;
        }
    }
}