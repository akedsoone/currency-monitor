namespace CurrencyMonitor.Api.Models
{
    public class ApiResponseBase
    {
        public string Result { get; set; } = string.Empty;
        public string ErrorCode { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string DocRefNumber { get; set; } = string.Empty;
        public DateTime DocDateTime { get; set; }
    }
}