// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cadence.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The interest payment.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Common
{
    /// <summary>
    /// The interest payment.
    /// </summary>
    public enum Cadence
    {
        /// <summary>
        /// The none.
        /// </summary>
        None = 0,

        /// <summary>
        /// The daily.
        /// </summary>
        Daily = 1,

        /// <summary>
        /// The weekly.
        /// </summary>
        Weekly = 2,

        /// <summary>
        /// The monthly.
        /// </summary>
        Monthly = 3,

        /// <summary>
        /// The quarterly.
        /// </summary>
        Quarterly = 4,

        /// <summary>
        /// The semiannual.
        /// </summary>
        SemiAnnual = 5,

        /// <summary>
        /// The yearly.
        /// </summary>
        Yearly = 6,

        /// <summary>
        /// The in the end.
        /// </summary>
        InTheEnd = 7
    }
}