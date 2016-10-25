namespace Finances.DataLayer.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.ModelConfiguration;
    using Finances.Domain.Human;

    public class UserEntityConfiguration : EntityTypeConfiguration<UserEntity>
    {
        public UserEntityConfiguration()
        {
            this.HasKey(p => p.Code).ToTable("Users");
            this.Property(p => p.Email).IsRequired().HasMaxLength(200).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("IX_Email", 1) { IsUnique = true }));
            this.Property(p => p.Name).IsRequired().HasMaxLength(200);
            this.Property(p => p.Surname).IsRequired().HasMaxLength(200);
            this.Property(p => p.Nif).HasMaxLength(25);
            this.Property(p => p.HealthCare).HasMaxLength(25);
            this.Property(p => p.IdNumber).HasMaxLength(25);
            this.Property(p => p.Passport).HasMaxLength(25);
        }
    }
}