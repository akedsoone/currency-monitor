namespace CurrencyMonitor.Api.Models
{
    public class DepartmentAmountsResponse
    {
        public List<ApiDepartmentResponse> DepartmentAmounts { get; set; } = new();
        public ApiResponseBase ResponseBase { get; set; } = new();
    }
}
