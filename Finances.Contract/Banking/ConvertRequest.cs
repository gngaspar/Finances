namespace Finances.Contract.Banking
{
    /// <summary>
    /// The object used to convert
    /// </summary>
    public class ConvertRequest
    {
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets from currency.
        /// </summary>
        /// <value>From currency.</value>
        public string FromCurrency { get; set; }

        /// <summary>
        /// Gets or sets to currency.
        /// </summary>
        /// <value>To currency.</value>
        public string ToCurrency { get; set; }
    }
}