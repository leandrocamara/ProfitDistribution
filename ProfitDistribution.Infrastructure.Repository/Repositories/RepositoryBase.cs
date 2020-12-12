using System.Collections.Generic;
using System.Threading.Tasks;
using ProfitDistribution.Infrastructure.Repository.Repositories.Interfaces;

namespace ProfitDistribution.Infrastructure.Repository.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        // protected readonly DbContext Context;
        // protected readonly DbSet<TEntity> EntitySet;

        protected RepositoryBase( /*DbContext context*/)
        {
            // Context = context;
            // EntitySet = context.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetAsync(object id)
        {
            return null;
            // return await EntitySet.FindAsync(id);
        }

        public virtual async Task<IList<TEntity>> ListAllAsync()
        {
            return null;
            // return await EntitySet.ToListAsync();
        }

        public virtual async Task SaveAsync(TEntity entity)
        {
            // await UpdateAsync(entity);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            // if (!IsAttached(entity))
            // await EntitySet.AddAsync(entity);
            // await Context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            // EntitySet.Remove(entity);
            // await Context.SaveChangesAsync();
        }
    }
}