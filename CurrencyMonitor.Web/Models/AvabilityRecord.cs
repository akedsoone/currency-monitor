namespace CurrencyMonitor.Web.Models
{
    public class AvailabilityRecord
    {
        public long Id { get; set; }
        public int DepartmentId { get; set; }
        public string Currency { get; set; } = string.Empty;
        public int Amount { get; set; }
        public DateTime CheckedAt { get; set; }
    }
}