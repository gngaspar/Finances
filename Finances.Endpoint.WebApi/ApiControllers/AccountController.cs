// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountController.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The account Controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Endpoint.WebApi.ApiControllers
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;

    using Finances.Contract;
    using Finances.Contract.Accounting;
    using Finances.Domain;
    using Finances.Domain.Wrappers;

    /// <summary>
    /// The account Controller.
    /// </summary>
    [RoutePrefix( "Account" )]
    public class AccountController : BaseController, IAccountController
    {
        /// <summary>
        /// The service.
        /// </summary>
        private readonly IAccountService accountService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="accountService">The account Service.</param>
        public AccountController( IAccountService accountService )
        {
            this.accountService = accountService;
        }

        /// <summary>
        /// The list.
        /// </summary>
        /// <param name="owner">
        /// The owner for example 9B8B32D1-A950-4C11-B77D-6FEFFAA4C17B .
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        [Route( "{owner:guid}/List" )]
        [ResponseType( typeof( ActionResponse<AccountListResponse> ) )]
        public async Task<HttpResponseMessage> List( Guid owner, AccountListRequest input )
        {
            var request = new AccountList { Owner = owner, Request = input };

            return await this.ProcessActionAsync( request, this.accountService.List );
        }

        /// <summary>
        /// The get get current details.
        /// </summary>
        /// <param name="owner">
        /// The owner for example 9B8B32D1-A950-4C11-B77D-6FEFFAA4C17B .
        /// </param>
        /// <param name="account">
        /// The account.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        [Route( "{owner:guid}/Current/Details/{account:guid}" )]
        [ResponseType( typeof( ActionResponse<AccountListResponse> ) )]
        public async Task<HttpResponseMessage> GetCurrentDetails( Guid owner, Guid account )
        {
            var input = new CurrentDetails { Code = account, Owner = owner };
            return await this.ProcessActionAsync( input, this.accountService.GetCurrentDetails );
        }
    }
}