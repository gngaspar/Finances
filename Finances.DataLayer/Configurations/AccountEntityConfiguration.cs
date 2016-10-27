namespace Finances.DataLayer.Configurations
{
    using System.Data.Entity.ModelConfiguration;
    using Finances.Domain.Banking;

    public class AccountEntityConfiguration : EntityTypeConfiguration<AccountEntity>
    {
        public AccountEntityConfiguration()
        {
            this.HasKey(p => p.Code).ToTable("Accounts");
            this.Property(p => p.Code).IsRequired().HasColumnOrder(0);
            this.Property(p => p.Number).IsRequired().HasMaxLength(100).HasColumnOrder(1);
            this.Property(p => p.Description).IsRequired().HasMaxLength(100).HasColumnOrder(2);
            this.Property(p => p.Amount).IsRequired().HasPrecision(18, 2).HasColumnOrder(3);
            this.Property(p => p.StartDate).IsRequired().HasColumnType("Date").HasColumnOrder(4);
            this.Ignore(p => p.IsMine);
        }
    }
}