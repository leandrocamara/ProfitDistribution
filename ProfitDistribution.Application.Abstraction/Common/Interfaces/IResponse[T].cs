namespace ProfitDistribution.Application.Abstraction.Common.Interfaces
{
    public interface IResponse<TData> : IResponse
    {
        TData Data { get; }
    }
}