namespace Finances.Domain.Banking
{
    /// <summary>
    /// The Currency representantion on the database.
    /// </summary>
    /// <seealso cref="Finances.Domain.EntityDateTimeBase"/>
    public class CurrencyEntity : EntityDateTimeBase
    {
        private string _currency;

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
        /// Gets or sets the name of the currency.
        /// </summary>
        /// <value>The code.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the default order.
        /// </summary>
        /// <value>The Order.</value>
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets the reason to one euro.
        /// </summary>
        /// <value>The reason to one euro.</value>
        public decimal ReasonToOneEuro { get; set; }
    }
}