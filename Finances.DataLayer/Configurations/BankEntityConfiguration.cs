namespace Finances.DataLayer.Configurations
{
    using System.Data.Entity.ModelConfiguration;
    using Finances.Domain.Banking;

    public class BankEntityConfiguration : EntityTypeConfiguration<BankEntity>
    {
        public BankEntityConfiguration()
        {
            this.HasKey(p => p.Code).ToTable("Banks");
            this.Property(p => p.Name).IsRequired().HasMaxLength(100);
            this.Property(p => p.Country).IsRequired().HasMaxLength(5);
            this.Property(p => p.Swift).IsRequired().HasMaxLength(50);
            this.Property(p => p.Url).HasMaxLength(250);
        }
    }
}
