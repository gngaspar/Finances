using System.Data.Entity.ModelConfiguration;

namespace Finances.DataLayer.Configurations
{
    using Domain.Banking;

    public class AccountEntityConfiguration : EntityTypeConfiguration<AccountEntity>
    {
        public AccountEntityConfiguration()
        {
            this.HasKey(p => p.Code).ToTable("Accounts");
            this.Property(p => p.Description).IsRequired().HasMaxLength(100);
            this.Property(p => p.Amount).IsRequired().HasPrecision(18, 2);
        }
    }
}