﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SavingAccountIn.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the SavingAccountIn type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Accounting
{
    using System;
    using Finances.Contract.Common;

    /// <summary>
    /// The saving account in.
    /// </summary>
    public class SavingAccountIn : AccountInBase
    {
        /// <summary>
        /// Gets or sets the bank.
        /// </summary>
        public Guid Bank { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        public string Currency { get; set; }

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
        public Cadence InterestPayment { get; set; }

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