// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HistoryOut.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The history out.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Banking
{
    using System.Collections.Generic;

    /// <summary>
    /// The history out.
    /// </summary>
    public class HistoryOut : CurrencyOut
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public List<HistoryValue> Data { get; set; }
    }
}
