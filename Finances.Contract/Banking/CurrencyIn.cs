// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrencyIn.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The currency in.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Banking
{
    /// <summary>
    /// The currency in.
    /// </summary>
    public class CurrencyIn
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the reason to one euro.
        /// </summary>
        public decimal ReasonToOneEuro { get; set; }
    }
}