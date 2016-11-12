namespace Finances.Contract.Banking
{
    using System;

    public class CurrencyOut
    {
        /// <summary>
        /// Gets or sets the last change.
        /// </summary>
        /// <value>The change at.</value>
        public DateTime? ChangeAt { get; set; }

        /// <summary>
        /// Gets or sets the code of the currency.
        /// </summary>
        /// <value>The code.</value>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the currency.
        /// </summary>
        /// <value>The code.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the reason to one euro.
        /// </summary>
        /// <value>The reason to one euro.</value>
        public decimal ReasonToOneEuro { get; set; }
    }
}