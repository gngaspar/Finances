namespace Finances.Domain.Banking
{
    using System;

    /// <summary>
    /// The Currency representantion on the database.
    /// </summary>
    public class CurrencyHistoryEntity
    {
        private string _currency;

        /// <summary>
        /// Gets or sets the created at day.
        /// </summary>
        /// <value>The created at day.</value>
        public DateTime CreatedAtDay { get; set; }

        /// <summary>
        /// Gets or sets the code of the currency.
        /// </summary>
        /// <value>The code.</value>
        public string Currency
        {
            get { return _currency.ToUpper(); }
            set { _currency = value.ToUpper(); }
        }

        /// <summary>
        /// Gets or sets the reason to one euro.
        /// </summary>
        /// <value>The reason to one euro.</value>
        public decimal ReasonToOneEuro { get; set; }
    }
}