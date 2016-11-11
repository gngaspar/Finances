namespace Finances.Domain.Accounting
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The Current Account representantion on the database.
    /// </summary>
    /// <seealso cref="Finances.Domain.Accounting.AccountEntity"/>
    public class CurrentAccountEntity : AccountEntity
    {
        /// <summary>
        /// Gets or sets the Iban.
        /// </summary>
        /// <value>The iban.</value>
        [Required]
        [MaxLength(100)]
        public string Iban { get; set; }
    }
}