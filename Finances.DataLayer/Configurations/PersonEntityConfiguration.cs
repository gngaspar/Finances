namespace Finances.DataLayer.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.ModelConfiguration;
    using Finances.Domain.Human;

    public class PersonEntityConfiguration : EntityTypeConfiguration<PersonEntity>
    {
        public PersonEntityConfiguration()
        {
            this.HasKey(p => p.Code).ToTable("Persons");
            this.Property(p => p.Name).IsRequired().HasMaxLength(200);
            this.Property(p => p.Surname).IsRequired().HasMaxLength(200);
            this.Property(p => p.Email).HasMaxLength(200);
        }
    }
}