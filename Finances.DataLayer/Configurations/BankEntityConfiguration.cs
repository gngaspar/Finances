namespace Finances.DataLayer.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.ModelConfiguration;
    using Finances.Domain.Banking;

    /// <summary>
    /// The bank entity configuration.
    /// </summary>
    public class BankEntityConfiguration : EntityTypeConfiguration<BankEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankEntityConfiguration"/> class.
        /// </summary>
        public BankEntityConfiguration()
        {
            this.HasKey(p => p.Code).ToTable("Banks");
            this.Property(p => p.Code).IsRequired().HasColumnOrder(0);
            this.Property(p => p.Name).IsRequired().HasMaxLength(100).HasColumnOrder(1);
            this.Property(p => p.Country).IsRequired().HasMaxLength(5).HasColumnOrder(2);
            this.Property(p => p.Swift)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_Swift", 1) { IsUnique = true }))
                .HasColumnOrder(3);
            this.Property(p => p.Url).HasMaxLength(250).HasColumnOrder(4);
            this.Property(p => p.ChangeAt).HasColumnOrder(5);
            this.Property(p => p.CreatedAt).HasColumnOrder(6);
        }
    }
}