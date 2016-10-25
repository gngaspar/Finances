namespace Finances.DataLayer.Configurations
{
    using System.Data.Entity.ModelConfiguration;
    using Finances.Domain;

    public class CurrencyEntityConfiguration : EntityTypeConfiguration<CurrencyEntity>
    {
        public CurrencyEntityConfiguration()
        {
            this.Property(p => p.Code).IsRequired().HasMaxLength(10);
            this.HasKey(p => p.Code).ToTable("Currencies");
            
        }
    }
}
