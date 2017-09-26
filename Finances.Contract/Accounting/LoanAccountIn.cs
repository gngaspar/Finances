// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoanAccountIn.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the LoanAccountIn type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Accounting
{
    using System;

    /// <summary>
    /// The loan account in.
    /// </summary>
    public class LoanAccountIn : AccountInBase
    {
        /// <summary>
        /// Gets or sets the initial amount.
        /// </summary>
        public decimal InitialAmount { get; set; }

        /// <summary>
        /// Gets or sets the interest net rate.
        /// </summary>
        public decimal InterestNetRate { get; set; }

        /// <summary>
        /// Gets or sets the loan interest rate.
        /// </summary>
        public decimal LoanInterestRate { get; set; }

        /// <summary>
        /// Gets or sets the premium percentage.
        /// </summary>
        public decimal PremiumPercentage { get; set; }

        /// <summary>
        /// Gets or sets the loan end date.
        /// </summary>
        public DateTime LoanEndDate { get; set; }
    }
}