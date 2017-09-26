// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAccountService.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The AccountService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Domain
{
    using System;
    using System.Threading.Tasks;

    using Finances.Contract;
    using Finances.Contract.Accounting;
    using Finances.Domain.Wrappers;

    /// <summary>
    /// The AccountService interface.
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// The list.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<AccountListResponse> List( AccountList input );

        /// <summary>
        /// The add current account.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<Guid> AddCurrentAccount( Guid owner, CurrentAccountIn input );

        /// <summary>
        /// The add saving account.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="currentAccount">
        /// The current account.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<Guid> AddSavingAccount( Guid owner, Guid currentAccount, SavingAccountIn input );

        /// <summary>
        /// The add loan account.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="currentAccount">
        /// The current account.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<Guid> AddLoanAccount( Guid owner, Guid currentAccount, LoanAccountIn input );

        /// <summary>
        /// The get loan details.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="account">
        /// The account.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<LoanAccountOut> GetLoanDetails( Guid owner, Guid account );

        /// <summary>
        /// The get saving details.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="account">
        /// The account.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<SavingAccountOut> GetSavingDetails( Guid owner, Guid account );

        /// <summary>
        /// The get current details.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<CurrentAccountOut> GetCurrentDetails( CurrentDetails input );
    }
}