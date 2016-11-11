namespace Finances.Domain.Plastic
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Finances.Contract.Common;
    using Finances.Domain.Accounting;
    using Finances.Domain.Human;

    /// <summary>
    /// The Card representantion on the database.
    /// </summary>
    /// <seealso cref="Finances.Domain.EntityOwnerBankBase"/>
    public abstract class CardEntity : EntityOwnerBankBase
    {
        [Required]
        public virtual CurrentAccountEntity Account { get; set; }

        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        /// <value>The card number.</value>
        public string CardNumber { get; set; }

        /// <summary>
        /// Gets or sets the card provider.
        /// </summary>
        /// <value>The card provider.</value>
        [NotMapped]
        public CardProvider CardProvider { get; set; }

        /// <summary>
        /// Gets the card provider string.
        /// </summary>
        /// <value>The card provider string.</value>
        [Required]
        [MaxLength(100)]
        [Column("CardProvider")]
        public string CardProviderString => CardProvider.ToString();

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>The currency.</value>
        [Required]
        public virtual CurrencyEntity Currency { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the expire.
        /// </summary>
        /// <value>The expire.</value>
        public DateTime Expire { get; set; }

        /// <summary>
        /// Gets or sets the Holder object.
        /// </summary>
        /// <value>The holder.</value>
        [Required]
        public virtual PersonEntity Holder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is mine.
        /// </summary>
        /// <value><c>true</c> if this instance is mine; otherwise, <c>false</c>.</value>
        public bool IsMine => this.Holder.Code == this.Owner.Code;
    }
}