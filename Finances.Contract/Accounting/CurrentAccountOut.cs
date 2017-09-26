// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrentAccountOut.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the CurrentAccountOut type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Accounting
{
    using System.Collections.Generic;

    /// <summary>
    /// The current account out.
    /// </summary>
    public class CurrentAccountOut : AccountInBase
    {
        /// <summary>
        /// Gets or sets the IBAN.
        /// </summary>
        public string Iban { get; set; }

        /// <summary>
        /// Gets or sets the loans.
        /// </summary>
        public List<LoanAccountOut> Loans { get; set; }

        /// <summary>
        /// Gets or sets the savings.
        /// </summary>
        public List<SavingAccountOut> Savings { get; set; }
    }
}