using System.Threading.Tasks;
using ProfitDistribution.Domain.ValueObjects;

namespace ProfitDistribution.Domain.Profits.Interfaces
{
    public interface IProfitService
    {
        Task<ProfitDistribution> GetProfitDistribution(Money amountAvailable);
    }
}