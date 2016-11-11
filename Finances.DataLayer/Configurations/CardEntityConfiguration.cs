namespace Finances.DataLayer.Configurations
{
    using System.Data.Entity.ModelConfiguration;
    using Finances.Domain.Plastic;

    public class CardEntityConfiguration : EntityTypeConfiguration<CardEntity>
    {
        public CardEntityConfiguration()
        {
            this.HasKey(p => p.Code).ToTable("Cards");
            this.Property(p => p.Code).IsRequired().HasColumnOrder(0);
            this.Property(p => p.CardNumber).IsRequired().HasMaxLength(4).HasColumnOrder(1);
            this.Property(p => p.Description).IsRequired().HasMaxLength(100).HasColumnOrder(2);
            this.Property(p => p.Expire).HasColumnType("Date").HasColumnOrder(3);
            this.Property(p => p.ChangeAt).HasColumnOrder(4);
            this.Property(p => p.CreatedAt).HasColumnOrder(5);
            this.Ignore(p => p.IsMine);
        }
    }
}