// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrencyIn.cs" company="Gng">
// Gng ggaspar@netcabo.pt
// </copyright>
// <summary>
// Defines the CurrencyIn type.
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