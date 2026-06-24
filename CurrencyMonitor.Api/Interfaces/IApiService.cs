using CurrencyMonitor.Api.Models;

namespace CurrencyMonitor.Api.Interfaces
{
    public interface IApiService
    {
        Task<DepartmentAmountsResponse> GetAmountsAsync();
    }
}
