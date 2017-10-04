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

        public Task<HttpResponseMessage> List( Guid owner, AccountListRequest input )
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> GetCurrentDetails( Guid owner, Guid account )
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> GetLoanDetails( Guid owner, Guid account )
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> GetSavingDetails( Guid owner, Guid account )
        {
            throw new NotImplementedException();
        }
    }
}