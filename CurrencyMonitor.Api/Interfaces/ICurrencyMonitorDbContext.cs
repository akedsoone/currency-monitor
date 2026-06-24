using CurrencyMonitor.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CurrencyMonitor.Api.Interfaces
{
    public interface ICurrencyMonitorDbContext
    {
        DbSet<AvailabilityRecord> AvailabilityRecords { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}