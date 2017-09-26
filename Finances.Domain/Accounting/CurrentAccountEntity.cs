// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrentAccountEntity.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The Current Account representantion on the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Domain.Accounting
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The current account entity.
    /// </summary>
    /// <seealso cref="Finances.Domain.Accounting.AccountEntity"/>
    public class CurrentAccountEntity : AccountEntity
    {
        /// <summary>
        /// Gets or sets the IBAN.
        /// </summary>
        /// <value>The IBAN.</value>
        [Required]
        [MaxLength( 100 )]
        public string Iban { get; set; }
    }
}