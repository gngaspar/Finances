namespace Finances.Contract.Banking
{
    using System;

    public class CurrencyOut : CurrencyIn
    {
        /// <summary>
        /// Gets or sets the last change.
        /// </summary>
        /// <value>The change at.</value>
        public DateTime? ChangeAt { get; set; }

        /// <summary>
        /// Gets or sets the name of the currency.
        /// </summary>
        /// <value>The code.</value>
        public string Name { get; set; }
    }
}