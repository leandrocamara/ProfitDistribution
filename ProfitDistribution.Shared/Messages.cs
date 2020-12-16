using System.Collections.Generic;

namespace ProfitDistribution.Shared
{
    public static class Messages
    {
        public const string RequiredProperty = "Required property: {0}.";
        public const string InvalidValue = "Invalid value: {0}.";

        public const string OccupationAreaNotIncludedDistributionProfits =
            "Occupation Area not included in the distribution of profits: {0}";

        public static string Format(string message, string arg) => string.Format(message, arg);
        public static string Format(string message, IEnumerable<string> args) => string.Format(message, args);
    }
}