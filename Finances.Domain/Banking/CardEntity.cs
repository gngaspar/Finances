namespace Finances.Domain.Banking
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Finances.Common.Banking;
    using Finances.Domain.Human;

    public abstract class CardEntity : EntityOwnerBankBase
    {
        [Required]
        public virtual CurrentAccountEntity Account { get; set; }

        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        public string CardNumber { get; set; }

        [NotMapped]
        public CardProvider CardProvider { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("CardProvider")]
        public string CardProviderString => CardProvider.ToString();

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        [Required]
        public virtual CurrencyEntity Currency { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the expire.
        /// </summary>
        public DateTime Expire { get; set; }

        /// <summary>
        /// Gets or sets the Holder object.
        /// </summary>
        [Required]
        public virtual PersonEntity Holder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is mine.
        /// </summary>
        public bool IsMine => this.Holder.Code == this.Owner.Code;
    }
}