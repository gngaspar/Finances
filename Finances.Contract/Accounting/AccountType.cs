// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountType.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The account type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Accounting
{
    /// <summary>
    /// The account type.
    /// </summary>
    public enum AccountType
    {
        /// <summary>
        /// The current account.
        /// </summary>
        CurrentAccount,

        /// <summary>
        /// The loan account.
        /// </summary>
        LoanAccount,

        /// <summary>
        /// The saving account.
        /// </summary>
        SavingAccount
    }
}