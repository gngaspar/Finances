// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InterestPayment.cs" company="Gng">
// Gng ggaspar@netcabo.pt
// </copyright>
// <summary>
// Defines the InterestPayment type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Common
{
    /// <summary>
    /// The interest payment.
    /// </summary>
    public enum InterestPayment
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
        Semiannual = 5,

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