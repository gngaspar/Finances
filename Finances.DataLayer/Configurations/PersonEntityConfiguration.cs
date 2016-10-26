namespace Finances.DataLayer.Configurations
{
    using System.Data.Entity.ModelConfiguration;
    using Finances.Domain.Human;

    public class PersonEntityConfiguration : EntityTypeConfiguration<PersonEntity>
    {
        public PersonEntityConfiguration()
        {
            this.HasKey(p => p.Code).ToTable("Persons");
            this.Property(p => p.Code).IsRequired().HasColumnOrder(0);
            this.Property(p => p.Name).IsRequired().HasMaxLength(200).HasColumnOrder(1);
            this.Property(p => p.Surname).IsRequired().HasMaxLength(200).HasColumnOrder(2);
            this.Property(p => p.Email).HasMaxLength(200).HasColumnOrder(3);
            this.Property(p => p.ChangeAt).HasColumnOrder(4);
            this.Property(p => p.CreatedAt).HasColumnOrder(5);
        }
    }
}