namespace ProfitDistribution.Exception.DomainExceptions
{
    public class InvalidFieldException : DomainException
    {
        public InvalidFieldException(string message) : base(message)
        {
        }
    }
}