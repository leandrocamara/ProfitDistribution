namespace ProfitDistribution.API.ViewModels
{
    public class CommonResponseViewModel<T> : CommonResponseViewModel
    {
        public T Data { get; set; }

        public CommonResponseViewModel(bool success, T data, string message = null) : base(success, message)
        {
            Data = data;
        }
    }
}