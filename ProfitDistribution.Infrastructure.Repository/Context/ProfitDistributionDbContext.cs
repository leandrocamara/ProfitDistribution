using Firebase.Database;
using Microsoft.Extensions.Configuration;

namespace ProfitDistribution.Infrastructure.Repository.Context
{
    public class ProfitDistributionDbContext
    {
        public FirebaseClient Client { get; protected set; }

        public ProfitDistributionDbContext(
            IConfiguration configuration,
            string configConnectionString = "DefaultConnection")
        {
            Client = new FirebaseClient(configuration.GetConnectionString(configConnectionString));
        }
    }
}