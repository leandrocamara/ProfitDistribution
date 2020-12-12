namespace ProfitDistribution.API.ViewModels
{
    public class CommonResponseViewModel
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public CommonResponseViewModel(bool success, string message = null)
        {
            Success = success;
            Message = message;
        }
    }
}