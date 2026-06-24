using CurrencyMonitor.Api.Interfaces;
using CurrencyMonitor.Api.Models;

namespace CurrencyMonitor.Api.Services
{
    public class AvailabilityRecordService(ICurrencyMonitorDbContext db)
        : IAvailabilityRecordService
    {
        private readonly ICurrencyMonitorDbContext _db = db;

        public async Task SaveDepartmentResponseAsync(
            ApiDepartmentResponse response,
            DateTime checkedAt,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(response);

            foreach (var currencyAmount in response.CurrencyAmounts)
            {
                var record = new AvailabilityRecord
                {
                    DepartmentId = response.DepartmentID,
                    Currency = currencyAmount.Currency,
                    Amount = currencyAmount.Amount,
                    CheckedAt = checkedAt
                };

                _db.AvailabilityRecords.Add(record);
            }

            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}