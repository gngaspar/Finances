﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonEntityConfiguration.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The person entity configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.DataLayer.Configurations
{
    using System.Data.Entity.ModelConfiguration;
    using Finances.Domain.Human;

    /// <summary>
    /// The person entity configuration.
    /// </summary>
    public class PersonEntityConfiguration : EntityTypeConfiguration<PersonEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonEntityConfiguration"/> class.
        /// </summary>
        public PersonEntityConfiguration()
        {
            this.HasKey( p => p.Code ).ToTable( "Persons" );
            this.Property( p => p.Code ).IsRequired().HasColumnOrder( 0 );
            this.Property( p => p.OwnerCode ).IsRequired().HasColumnOrder( 1 );
            this.Property( p => p.Name ).IsRequired().HasMaxLength( 200 ).HasColumnOrder( 2 );
            this.Property( p => p.Surname ).IsRequired().HasMaxLength( 200 ).HasColumnOrder( 3 );
            this.Property( p => p.Email ).HasMaxLength( 200 ).HasColumnOrder( 4 );
            this.Property( p => p.IsArchived ).HasColumnOrder( 5 );
            this.Property( p => p.ChangeAt ).HasColumnOrder( 6 );
            this.Property( p => p.CreatedAt ).HasColumnOrder( 7 );
            this.Ignore( i => i.IsMe );
        }
    }
}