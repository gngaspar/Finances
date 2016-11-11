namespace Finances.Domain
{
    using System.ComponentModel.DataAnnotations;
    using Finances.Domain.Banking;

    /// <summary>
    /// The Entity even more expanded, to have information about each bank its related
    /// </summary>
    /// <seealso cref="Finances.Domain.EntityOwnerBase"/>
    public abstract class EntityOwnerBankBase : EntityOwnerBase
    {
        /// <summary>
        /// Gets or sets the the bank.
        /// </summary>
        /// <value>The bank.</value>
        [Required]
        public virtual BankEntity Bank { get; set; }
    }
}