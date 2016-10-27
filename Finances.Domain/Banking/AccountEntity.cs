namespace Finances.Domain.Banking
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Finances.Domain.Human;

    public abstract class AccountEntity : EntityOwnerBankBase
    {
        /// <summary>
        /// Gets or sets the Amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        [Required]
        public virtual CurrencyEntity Currency { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Holder object.
        /// </summary>
        public virtual PersonEntity Holder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is mine.
        /// </summary>
        public bool IsMine => this.Holder.Code == this.Owner.Code;

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public string Number { get; set; }

        public DateTime StartDate { get; set; }
    }
}