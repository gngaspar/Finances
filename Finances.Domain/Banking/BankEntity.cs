namespace Finances.Domain.Banking
{
    using System;

    /// <summary>
    /// The Bank representantion on the database.
    /// </summary>
    /// <seealso cref="Finances.Domain.EntityDateTimeBase"/>
    public class BankEntity : EntityDateTimeBase
    {
        /// <summary>
        /// Gets or sets the Code.
        /// </summary>
        /// <value>The code.</value>
        public Guid Code { get; set; }

        /// <summary>
        /// Gets or sets the Country.
        /// </summary>
        /// <value>The country.</value>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Swift.
        /// </summary>
        /// <value>The swift.</value>
        public string Swift { get; set; }

        /// <summary>
        /// Gets or sets the Url.
        /// </summary>
        /// <value>The URL.</value>
        public string Url { get; set; }
    }
}