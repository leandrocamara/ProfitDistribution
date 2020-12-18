using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProfitDistribution.Infrastructure.Repository.Repositories.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<IList<TEntity>> GetAllAsync();

        Task SaveAsync(TEntity entity);
    }
}