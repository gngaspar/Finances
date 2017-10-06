// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoanAccountOut.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the LoanAccountOut type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Accounting
{
    using System;

    using Finances.Contract.Banking;

    /// <summary>
    /// The loan account out.
    /// </summary>
    public class LoanAccountOut : AccountInBase
    {
        /// <summary>
        /// Gets or sets the bank.
        /// </summary>
        public BankOut Bank { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        public CurrencyOut Currency { get; set; }

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