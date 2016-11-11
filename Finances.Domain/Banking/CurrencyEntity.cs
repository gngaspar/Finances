namespace Finances.Domain.Banking
{
    /// <summary>
    /// The Currency representantion on the database.
    /// </summary>
    /// <seealso cref="Finances.Domain.EntityDateTimeBase"/>
    public class CurrencyEntity : EntityDateTimeBase
    {
        /// <summary>
        /// Gets or sets the code of the currency.
        /// </summary>
        /// <value>The code.</value>
        public string Currency { get; set; }

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