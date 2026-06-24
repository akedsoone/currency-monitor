using CurrencyMonitor.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CurrencyMonitor.Web.Data.Configurations
{
    public class AvailabilityRecordConfiguration
        : IEntityTypeConfiguration<AvailabilityRecord>
    {
        public void Configure(EntityTypeBuilder<AvailabilityRecord> builder)
        {
            _ = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable("AvailabilityRecord")
                .HasKey(record => record.Id);

            builder.Property(record => record.DepartmentId)
                .IsRequired();

            builder.Property(record => record.Currency)
                .IsRequired()
                .HasMaxLength(3);

            builder.Property(record => record.Amount)
                .IsRequired();

            builder.Property(record => record.CheckedAt)
                .IsRequired();
        }
    }
}