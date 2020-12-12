using System.Collections.Generic;

namespace ProfitDistribution.Shared
{
    public static class Messages
    {
        public const string RegisterNotFound = "Register not found.";

        public static string RequiredField(string field) => Format(MsgRequiredField, field);
        public static string InvalidField(string field) => Format(MsgInvalidField, field);

        private static string Format(string message, string arg)
        {
            return string.Format(message, arg);
        }

        private static string Format(string message, IEnumerable<string> fields)
        {
            return string.Format(message, fields);
        }

        private const string MsgRequiredField = "Required field: {0}.";
        private const string MsgInvalidField = "Invalid field: {0}.";
    }
}