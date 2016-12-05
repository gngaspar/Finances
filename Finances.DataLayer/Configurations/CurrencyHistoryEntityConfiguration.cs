namespace Finances.DataLayer.Configurations
{
    using System.Data.Entity.ModelConfiguration;
    using Finances.Domain.Banking;

    /// <summary>
    /// The currency history entity configuration.
    /// </summary>
    public class CurrencyHistoryEntityConfiguration : EntityTypeConfiguration<CurrencyHistoryEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyHistoryEntityConfiguration"/> class.
        /// </summary>
        public CurrencyHistoryEntityConfiguration()
        {
            this.HasKey(p => new { p.Currency, p.CreatedAtDay }).ToTable("CurrencyHistory");
            this.Property(p => p.Currency).IsRequired().HasMaxLength(3).HasColumnOrder(0);
            this.Property(p => p.CreatedAtDay).IsRequired().HasColumnType("Date").HasColumnOrder(1);
            this.Property(p => p.ReasonToOneEuro).IsRequired().HasPrecision(12, 5).HasColumnOrder(2);
        }
    }
}