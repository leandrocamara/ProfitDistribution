using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProfitDistribution.Infrastructure.Repository.Repositories.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(object id);

        Task<IList<TEntity>> ListAllAsync();

        Task SaveAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);
    }
}