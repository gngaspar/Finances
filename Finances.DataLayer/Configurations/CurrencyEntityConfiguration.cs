namespace Finances.DataLayer.Configurations
{
    using System.Data.Entity.ModelConfiguration;
    using Finances.Domain;
    using Finances.Domain.Banking;

    public class CurrencyEntityConfiguration : EntityTypeConfiguration<CurrencyEntity>
    {
        public CurrencyEntityConfiguration()
        {
            this.HasKey(p => p.CodeName).ToTable("Currencies");
            this.Property(p => p.CodeName).IsRequired().HasMaxLength(10).HasColumnOrder(0);
            this.Property(p => p.ReasonToOneEuro).IsRequired().HasPrecision(12, 2).HasColumnOrder(1);
            this.Property(p => p.ChangeAt).HasColumnOrder(2);
            this.Property(p => p.CreatedAt).HasColumnOrder(3);
        }
    }
}