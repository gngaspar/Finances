namespace Finances.Contract.Banking
{
    using System;

    public class Bank
    {
        /// <summary>
        /// Gets or sets the Code.
        /// </summary>
        public Guid Code { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the Country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the Swift.
        /// </summary>
        public string Swift { get; set; }
    }
}
