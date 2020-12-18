using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database.Query;
using ProfitDistribution.Exception;
using ProfitDistribution.Infrastructure.Repository.Context;
using ProfitDistribution.Infrastructure.Repository.Repositories.Contracts;
using ProfitDistribution.Infrastructure.Repository.Repositories.Interfaces;
using ProfitDistribution.Shared;

namespace ProfitDistribution.Infrastructure.Repository.Repositories
{
    public abstract class RepositoryBase<TEntity, TEntityContract> : IRepositoryBase<TEntity>
        where TEntity : class
        where TEntityContract : IContract<TEntity>
    {
        protected readonly ProfitDistributionDbContext Context;

        private readonly string _resourceName;

        protected RepositoryBase(ProfitDistributionDbContext context, string resourceName)
        {
            Context = context;
            _resourceName = resourceName;
        }

        public virtual async Task<IList<TEntity>> GetAllAsync()
        {
            try
            {
                var entities = await Context.Client.Child(_resourceName).OnceSingleAsync<List<TEntityContract>>();
                return entities.Select(e => e.Parse()).ToList();
            }
            catch (System.Exception)
            {
                throw new BaseException(Messages.ConnectionDatabaseFailed);
            }
        }

        public virtual async Task SaveAsync(TEntity entity)
        {
            try
            {
                await Context.Client.Child(_resourceName).PostAsync(entity);
            }
            catch (System.Exception e)
            {
                throw new BaseException(e.Message);
            }
        }
    }
}