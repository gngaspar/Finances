// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserEntityConfiguration.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The user entity configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.DataLayer.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.ModelConfiguration;
    using Finances.Domain.Human;

    /// <summary>
    /// The user entity configuration.
    /// </summary>
    public class UserEntityConfiguration : EntityTypeConfiguration<UserEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserEntityConfiguration"/> class.
        /// </summary>
        public UserEntityConfiguration()
        {
            this.HasKey( p => p.Code ).ToTable( "Users" );
            this.Property( p => p.Code ).IsRequired().HasColumnOrder( 0 );
            this.Property( p => p.Email )
                .IsRequired()
                .HasMaxLength( 200 )
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation( new IndexAttribute( "IX_Email", 1 ) { IsUnique = true } ) )
                .HasColumnOrder( 1 );
            this.Property( p => p.Name ).IsRequired().HasMaxLength( 200 ).HasColumnOrder( 2 );
            this.Property( p => p.Surname ).IsRequired().HasMaxLength( 200 ).HasColumnOrder( 3 );
            this.Property( p => p.IdNumber ).HasMaxLength( 25 ).HasColumnOrder( 4 );
            this.Property( p => p.IdNumberExpirationDate ).HasColumnType( "Date" ).HasColumnOrder( 5 );
            this.Property( p => p.Passport ).HasMaxLength( 25 ).HasColumnOrder( 6 );
            this.Property( p => p.PassportExpirationDate ).HasColumnType( "Date" ).HasColumnOrder( 7 );
            this.Property( p => p.Nif ).HasMaxLength( 25 ).HasColumnOrder( 8 );
            this.Property( p => p.HealthCare ).HasMaxLength( 25 ).HasColumnOrder( 9 );
            this.Property( p => p.HealthCareExpirationDate ).HasColumnOrder( 10 );
            this.Property( p => p.SocialSecurity ).HasMaxLength( 25 ).HasColumnOrder( 11 );
            this.Property( p => p.ChangeAt ).HasColumnOrder( 12 );
            this.Property( p => p.CreatedAt ).HasColumnOrder( 13 );
        }
    }
}