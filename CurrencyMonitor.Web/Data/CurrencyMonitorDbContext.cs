using CurrencyMonitor.Web.Data.Configurations;
using CurrencyMonitor.Web.Interfaces;
using CurrencyMonitor.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CurrencyMonitor.Web.Data
{
    public class CurrencyMonitorDbContext(
        DbContextOptions<CurrencyMonitorDbContext> options) : DbContext(options), ICurrencyMonitorDbContext
    {
        public DbSet<AvailabilityRecord> AvailabilityRecords { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(
                new AvailabilityRecordConfiguration());

            modelBuilder.Entity<AvailabilityRecord>()
                .ToTable("AvailabilityRecord", t => t.ExcludeFromMigrations());

            base.OnModelCreating(modelBuilder);
        }
    }
}