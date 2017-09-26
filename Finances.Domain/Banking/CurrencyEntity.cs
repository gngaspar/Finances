// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrencyEntity.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The Currency representantion on the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Domain.Banking
{
    /// <summary>
    /// The currency entity.
    /// </summary>
    /// <seealso cref="Finances.Domain.EntityDateTimeBase"/>
    public class CurrencyEntity : EntityDateTimeBase
    {
        /// <summary>
        /// The currency.
        /// </summary>
        private string currency;

        /// <summary>
        /// Gets or sets the code of the currency.
        /// </summary>
        /// <value>The code.</value>
        public string Currency
        {
            get { return this.currency.ToUpper(); }
            set { this.currency = value.ToUpper(); }
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