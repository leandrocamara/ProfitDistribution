namespace ProfitDistribution.Shared
{
    public static class Messages
    {
        public const string RequiredProperty = "Required property: {0}";
        public const string InvalidValue = "Invalid value: {0}";
        public const string InvalidMoney = "Invalid money";
        public const string ConnectionDatabaseFailed = "Connection to the database failed. Please try again later.";

        public const string OccupationAreaNotIncludedDistributionProfits =
            "Occupation Area not included in the distribution of profits: {0}";

        public const string InsufficientAmountAvailable =
            "Insufficient amount available. Balance Required: {0}. Current Balance: {1}";

        public static string Format(string message, string arg) => string.Format(message, arg);
        public static string Format(string message, object[] args) => string.Format(message, args);
    }
}