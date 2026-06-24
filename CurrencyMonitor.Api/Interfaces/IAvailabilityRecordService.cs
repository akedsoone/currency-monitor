using CurrencyMonitor.Api.Models;

namespace CurrencyMonitor.Api.Interfaces
{
    public interface IAvailabilityRecordService
    {
        Task SaveDepartmentResponseAsync(
            ApiDepartmentResponse response,
            DateTime checkedAt,
            CancellationToken cancellationToken = default);
    }
}