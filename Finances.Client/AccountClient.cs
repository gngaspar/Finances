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
        /// The get get current details.
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
        public Task<HttpResponseMessage> GetGetCurrentDetails( Guid owner, Guid account )
        {
            return null;
        }
    }
}