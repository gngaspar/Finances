namespace Finances.Domain.Banking
{
    public abstract class AccountEntity : EntityOwnerBase
    {
        /// <summary>
        /// Gets or sets the currency.
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
        /// Gets or sets the Holder name.
        /// </summary>
        public string Holder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is mine.
        /// </summary>
        public bool IsMine { get; set; }
    }
}
