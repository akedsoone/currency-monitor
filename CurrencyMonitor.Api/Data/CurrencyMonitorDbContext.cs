using CurrencyMonitor.Api.Data.Configurations;
using CurrencyMonitor.Api.Interfaces;
using CurrencyMonitor.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CurrencyMonitor.Api.Data
{
    public class CurrencyMonitorDbContext(
        DbContextOptions<CurrencyMonitorDbContext> options) : DbContext(options), ICurrencyMonitorDbContext
    {
        public DbSet<AvailabilityRecord> AvailabilityRecords { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(
                new AvailabilityRecordConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}