// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CardEntityConfiguration.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The card entity configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.DataLayer.Configurations
{
    using System.Data.Entity.ModelConfiguration;

    using Finances.Domain.Plastic;

    /// <summary>
    /// The card entity configuration.
    /// </summary>
    public class CardEntityConfiguration : EntityTypeConfiguration<CardEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CardEntityConfiguration"/> class.
        /// </summary>
        public CardEntityConfiguration()
        {
            this.HasKey( p => new { p.Code, p.Bank, p.Account, p.Owner } ).ToTable( "Cards" );
            this.Property( p => p.Code ).IsRequired().HasColumnOrder( 0 );
            this.Property( p => p.CardNumber ).IsRequired().HasMaxLength( 4 ).HasColumnOrder( 1 );
            this.Property( p => p.Description ).IsRequired().HasMaxLength( 100 ).HasColumnOrder( 2 );
            this.Property( p => p.Expire ).HasColumnType( "Date" ).HasColumnOrder( 3 );
            this.Property( p => p.Currency ).IsRequired().HasMaxLength( 3 ).HasColumnOrder( 4 );
            this.Property( p => p.ChangeAt ).HasColumnOrder( 5 );
            this.Property( p => p.CreatedAt ).HasColumnOrder( 6 );
            this.Property( p => p.Bank ).IsRequired().HasColumnOrder( 7 );
            this.Property( p => p.Account ).IsRequired().HasColumnOrder( 8 );
            this.Property( p => p.Owner ).IsRequired().HasColumnOrder( 9 );
            this.Ignore( p => p.IsMine );
        }
    }
}