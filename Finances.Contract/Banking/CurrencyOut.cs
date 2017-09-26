// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrencyOut.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The currency out.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Banking
{
    using System;

    /// <summary>
    /// The currency out.
    /// </summary>
    public class CurrencyOut : CurrencyIn
    {
        /// <summary>
        /// Gets or sets the change at.
        /// </summary>
        public DateTime? ChangeAt { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }
    }
}