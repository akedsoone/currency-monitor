using CurrencyMonitor.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CurrencyMonitor.Web.Interfaces
{
    public interface ICurrencyMonitorDbContext
    {
        DbSet<AvailabilityRecord> AvailabilityRecords { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}