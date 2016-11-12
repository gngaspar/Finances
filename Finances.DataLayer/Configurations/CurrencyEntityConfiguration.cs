namespace Finances.DataLayer.Configurations
{
    using System.Data.Entity.ModelConfiguration;
    using Finances.Domain.Banking;

    public class CurrencyEntityConfiguration : EntityTypeConfiguration<CurrencyEntity>
    {
        public CurrencyEntityConfiguration()
        {
            this.HasKey(p => p.Currency).ToTable("Currencies");
            this.Property(p => p.Currency).IsRequired().HasMaxLength(3).HasColumnOrder(0);
            this.Property(p => p.Name).IsRequired().HasMaxLength(50).HasColumnOrder(1);
            this.Property(p => p.Order).IsRequired().HasColumnOrder(2);
            this.Property(p => p.ReasonToOneEuro).IsRequired().HasPrecision(12, 5).HasColumnOrder(3);
            this.Property(p => p.ChangeAt).HasColumnOrder(4);
            this.Property(p => p.CreatedAt).HasColumnOrder(5);
        }
    }
}