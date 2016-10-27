namespace Finances.Domain
{
    using System.ComponentModel.DataAnnotations;
    using Finances.Domain.Banking;

    public abstract class EntityOwnerBankBase : EntityOwnerBase
    {
        /// <summary>
        /// Gets or sets the the bank.
        /// </summary>
        [Required]
        public virtual BankEntity Bank { get; set; }
    }
}