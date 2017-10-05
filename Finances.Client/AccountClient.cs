// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountClient.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The account client.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Client
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Finances.Client.Common;
    using Finances.Contract.Accounting;

    /// <summary>
    /// The account client.
    /// </summary>
    public class AccountClient : ClientBase, IAccountController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountClient"/> class.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        public AccountClient( IRestSender sender )
            : base( sender )
        {
        }

        /// <summary>
        /// The list.
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
        public Task<HttpResponseMessage> List( Guid owner, AccountListRequest input )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get current details.
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
        public Task<HttpResponseMessage> GetCurrentDetails( Guid owner, Guid account )
        {
            throw new NotImplementedException();
        }

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
        public Task<HttpResponseMessage> GetLoanDetails( Guid owner, Guid account )
        {
            throw new NotImplementedException();
        }

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
        public Task<HttpResponseMessage> GetSavingDetails( Guid owner, Guid account )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The add current details.
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
        public Task<HttpResponseMessage> AddCurrentDetails( Guid owner, CurrentAccountIn account )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The add loan details.
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
        public Task<HttpResponseMessage> AddLoanDetails( Guid owner, LoanAccountIn account )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The add loan details.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="currentAccount">
        /// The current account.
        /// </param>
        /// <param name="account">
        /// The account.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<HttpResponseMessage> AddLoanDetails( Guid owner, Guid currentAccount, LoanAccountIn account )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The add savings details.
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
        public Task<HttpResponseMessage> AddSavingDetails( Guid owner, SavingAccountIn account )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The add loan details.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="currentAccount">
        /// The current account.
        /// </param>
        /// <param name="account">
        /// The account.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<HttpResponseMessage> AddSavingDetails( Guid owner, Guid currentAccount, SavingAccountIn account )
        {
            throw new NotImplementedException();
        }
    }
}