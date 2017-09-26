// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAccountRepository.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The AccountRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Domain.Repository
{
    using System;
    using System.Threading.Tasks;

    using Finances.Contract.Accounting;

    /// <summary>
    /// The AccountRepository interface.
    /// </summary>
    public interface IAccountRepository : IDisposable
    {
        /// <summary>
        /// The list.
        /// </summary>
        /// <param name="owner">
        /// The owner of the portfolio.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<AccountListResponse> List( Guid owner, AccountListRequest input );

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<int> Add( Guid owner, Guid code, CurrentAccountIn input );

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="currentAccount">
        /// The current account.
        /// </param>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<int> Add( Guid owner, Guid currentAccount, Guid code, LoanAccountIn input );

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="currentAccount">
        /// The current account.
        /// </param>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<int> Add( Guid owner, Guid currentAccount, Guid code, SavingAccountIn input );

        /// <summary>
        /// The get current.
        /// </summary>
        /// <param name="account">
        /// The account.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<CurrentAccountOut> GetCurrent( Guid account );

        /// <summary>
        /// The get loan.
        /// </summary>
        /// <param name="account">
        /// The account.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<LoanAccountOut> GetLoan( Guid account );

        /// <summary>
        /// The get saving.
        /// </summary>
        /// <param name="account">
        /// The account.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<SavingAccountOut> GetSaving( Guid account );

        /// <summary>
        /// The is owner.
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
        Task<bool> IsOwner( Guid owner, Guid account );
    }
}