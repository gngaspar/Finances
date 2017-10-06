// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HistoryValue.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The history value.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Banking
{
    using System;

    /// <summary>
    /// The history value.
    /// </summary>
    public class HistoryValue
    {
        /// <summary>
        /// Gets or sets the reason to one euro.
        /// </summary>
        public decimal ReasonToOneEuro { get; set; }

        /// <summary>
        /// Gets or sets the change at.
        /// </summary>
        public DateTime ChangeAt { get; set; }
    }
}
