namespace ProfitDistribution.Infrastructure.Repository.Repositories.Contracts
{
    public interface IContract<out TEntity> where TEntity : class
    {
        TEntity Parse();
    }
}