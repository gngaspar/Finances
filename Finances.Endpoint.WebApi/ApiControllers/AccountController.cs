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
        /// The owner for example 9B8B32D1-A950-4C11-B77D-6FEFFAA4C17B
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
        /// The get current details.
        /// </summary>
        /// <param name="owner">
        /// The owner for example 9B8B32D1-A950-4C11-B77D-6FEFFAA4C17B
        /// </param>
        /// <param name="account">
        /// The account.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet]
        [Route( "{owner:guid}/Current/{account:guid}/Details" )]
        [ResponseType( typeof( ActionResponse<CurrentAccountOut> ) )]
        public async Task<HttpResponseMessage> GetCurrentDetails( Guid owner, Guid account )
        {
            var input = new AccountDetails { Code = account, Owner = owner };
            return await this.ProcessActionAsync( input, this.accountService.GetCurrentDetails );
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
        [HttpPost]
        [Route( "{owner:guid}/Current/Add" )]
        [ResponseType( typeof( ActionResponse<Guid> ) )]
        public async Task<HttpResponseMessage> AddCurrentDetails( Guid owner, CurrentAccountIn account )
        {
            return await this.ProcessActionAsync( owner, account, this.accountService.AddCurrentAccount );
        }

        /// <summary>
        /// The add loan details.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="loan">
        /// The account.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        [Route( "{owner:guid}/Loan/Add" )]
        [ResponseType( typeof( ActionResponse<Guid> ) )]
        public async Task<HttpResponseMessage> AddLoanDetails( Guid owner, LoanAccountIn loan )
        {
            var input = new AccountAdd { CurrentAccount = Guid.Empty, Loan = loan };
            return await this.ProcessActionAsync( owner, input, this.accountService.AddLoanAccount );
        }

        /// <summary>
        /// The add loan details.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="account">
        /// The current account.
        /// </param>
        /// <param name="loan">
        /// The loan.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        [Route( "{owner:guid}/Current/{account:guid}/Loan" )]
        [ResponseType( typeof( ActionResponse<Guid> ) )]
        public async Task<HttpResponseMessage> AddLoanDetails( Guid owner, Guid account, LoanAccountIn loan )
        {
            var input = new AccountAdd { CurrentAccount = account, Loan = loan };
            return await this.ProcessActionAsync( owner, input, this.accountService.AddLoanAccount );
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
        [HttpPost]
        [Route( "{owner:guid}/Saving/Add" )]
        [ResponseType( typeof( ActionResponse<Guid> ) )]
        public async Task<HttpResponseMessage> AddSavingDetails( Guid owner, SavingAccountIn account )
        {
            var input = new AccountAdd { CurrentAccount = Guid.Empty, Saving = account };
            return await this.ProcessActionAsync( owner, input, this.accountService.AddSavingAccount );
        }

        /// <summary>
        /// The add saving details.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="account">
        /// The current account.
        /// </param>
        /// <param name="saving">
        /// The account.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        [Route( "{owner:guid}/Current/{account:guid}/Saving" )]
        [ResponseType( typeof( ActionResponse<Guid> ) )]
        public async Task<HttpResponseMessage> AddSavingDetails( Guid owner, Guid account, SavingAccountIn saving )
        {
            var input = new AccountAdd { CurrentAccount = account, Saving = saving };
            return await this.ProcessActionAsync( owner, input, this.accountService.AddSavingAccount );
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
        [HttpGet]
        [Route( "{owner:guid}/Loan/{account:guid}/Details" )]
        [ResponseType( typeof( ActionResponse<LoanAccountOut> ) )]
        public async Task<HttpResponseMessage> GetLoanDetails( Guid owner, Guid account )
        {
            var input = new AccountDetails { Code = account, Owner = owner };
            return await this.ProcessActionAsync( input, this.accountService.GetLoanDetails );
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
        [HttpGet]
        [Route( "{owner:guid}/Saving/{account:guid}/Details" )]
        [ResponseType( typeof( ActionResponse<LoanAccountOut> ) )]
        public async Task<HttpResponseMessage> GetSavingDetails( Guid owner, Guid account )
        {
            var input = new AccountDetails { Code = account, Owner = owner };
            return await this.ProcessActionAsync( input, this.accountService.GetSavingDetails );
        }
    }
}