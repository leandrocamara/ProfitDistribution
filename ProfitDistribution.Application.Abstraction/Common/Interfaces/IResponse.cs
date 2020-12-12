using ProfitDistribution.Exception;

namespace ProfitDistribution.Application.Abstraction.Common.Interfaces
{
    public interface IResponse
    {
        bool Success { get; }

        BaseException Exception { get; }
    }
}