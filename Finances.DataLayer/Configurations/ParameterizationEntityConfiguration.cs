namespace Finances.DataLayer.Configurations
{
    using System.Data.Entity.ModelConfiguration;
    using Finances.Domain.Projection;

    public class ParameterizationEntityConfiguration : EntityTypeConfiguration<ParameterizationEntity>
    {
        public ParameterizationEntityConfiguration()
        {
            this.HasKey(p => p.Code).ToTable("Parameterizations");
            this.Property(p => p.Code).IsRequired().HasColumnOrder(0);
            this.Property(p => p.Description).IsRequired().HasMaxLength(100).HasColumnOrder(1);
            this.Property(p => p.Amount).IsRequired().HasPrecision(12, 2).HasColumnOrder(2);
            this.Property(p => p.Active).IsRequired().HasColumnOrder(3);
            this.Ignore(p => p.IsMain);
            this.Property(p => p.SpecificDay).HasColumnType("Date").HasColumnOrder(4);
            this.Property(p => p.Day).HasColumnOrder(5);
            this.Property(p => p.ChangeAt).HasColumnOrder(6);
            this.Property(p => p.CreatedAt).HasColumnOrder(7);
        }
    }
}