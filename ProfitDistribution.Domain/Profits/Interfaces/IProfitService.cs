using System.Threading.Tasks;

namespace ProfitDistribution.Domain.Profits.Interfaces
{
    public interface IProfitService
    {
        Task<ProfitDistribution> GetProfitDistribution(double amountAvailable);
    }
}