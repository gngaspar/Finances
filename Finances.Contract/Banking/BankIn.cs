// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BankIn.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The bank in.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Banking
{
    /// <summary>
    /// The bank in.
    /// </summary>
    public class BankIn
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the swift.
        /// </summary>
        public string Swift { get; set; }

        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        public string Url { get; set; }
    }
}