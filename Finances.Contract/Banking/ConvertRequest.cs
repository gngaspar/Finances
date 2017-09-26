// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConvertRequest.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The convert request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Banking
{
    /// <summary>
    /// The convert request.
    /// </summary>
    public class ConvertRequest
    {
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the from currency.
        /// </summary>
        public string FromCurrency { get; set; }

        /// <summary>
        /// Gets or sets the to currency.
        /// </summary>
        public string ToCurrency { get; set; }
    }
}