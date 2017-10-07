// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SavingAccountOut.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the SavingAccountOut type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Accounting
{
    using System;

    using Finances.Contract.Banking;
    using Finances.Contract.Common;

    /// <summary>
    /// The saving account out.
    /// </summary>
    public class SavingAccountOut : AccountInBase
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
        /// Gets or sets the holder.
        /// </summary>
        public Guid Holder { get; set; }

        /// <summary>
        /// Gets or sets the automatic renovation.
        /// </summary>
        public AutomaticRenovation AutomaticRenovation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether interest capitalization.
        /// </summary>
        public bool InterestCapitalization { get; set; }

        /// <summary>
        /// Gets or sets the interest payment.
        /// </summary>
        public InterestPayment InterestPayment { get; set; }

        /// <summary>
        /// Gets or sets the saving end date.
        /// </summary>
        public DateTime SavingEndDate { get; set; }

        /// <summary>
        /// Gets or sets the saving interest rate.
        /// </summary>
        public decimal SavingInterestRate { get; set; }
    }
}