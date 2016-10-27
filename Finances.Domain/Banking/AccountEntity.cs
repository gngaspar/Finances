namespace Finances.Domain.Banking
{
    using Finances.Domain.Human;

    public abstract class AccountEntity : EntityOwnerBase
    {
        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        public CurrencyEntity Currency { get; set; }

        /// <summary>
        /// Gets or sets the Amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the Holder object.
        /// </summary>
        public UserEntity Holder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is mine.
        /// </summary>
        public bool IsMine => this.Holder.Code == this.Owner.Code;
    }
}