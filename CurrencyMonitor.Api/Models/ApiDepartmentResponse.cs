namespace CurrencyMonitor.Api.Models
{
    public class ApiDepartmentResponse
    {
        public int DepartmentID { get; set; }
        public List<CurrencyAmount> CurrencyAmounts { get; set; } = new(); 

    }
}
