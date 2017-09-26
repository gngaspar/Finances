// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountEntityConfiguration.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The account entity configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.DataLayer.Configurations
{
    using System.Data.Entity.ModelConfiguration;

    using Finances.Domain.Accounting;

    /// <summary>
    /// The account entity configuration.
    /// </summary>
    public class AccountEntityConfiguration : EntityTypeConfiguration<AccountEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountEntityConfiguration"/> class.
        /// </summary>
        public AccountEntityConfiguration()
        {
            this.HasKey( p => new { p.Code, p.Bank, p.Owner } ).ToTable( "Accounts" );
            this.Property( p => p.Code ).IsRequired().HasColumnOrder( 0 );
            this.Property( p => p.Number ).IsRequired().HasMaxLength( 100 ).HasColumnOrder( 1 );
            this.Property( p => p.Description ).IsRequired().HasMaxLength( 100 ).HasColumnOrder( 2 );
            this.Property( p => p.Amount ).IsRequired().HasPrecision( 18, 2 ).HasColumnOrder( 3 );
            this.Property( p => p.StartDate ).IsRequired().HasColumnType( "Date" ).HasColumnOrder( 4 );
            this.Property( p => p.Currency ).IsRequired().HasMaxLength( 3 ).HasColumnOrder( 5 );
            this.Property( p => p.Bank ).IsRequired().HasColumnOrder( 6 );
            this.Property( p => p.Owner ).IsRequired().HasColumnOrder( 7 );
            this.Ignore( p => p.IsMine );
        }
    }
}