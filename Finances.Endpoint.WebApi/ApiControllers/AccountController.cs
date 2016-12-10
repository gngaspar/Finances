namespace Finances.Endpoint.WebApi.ApiControllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Http;

    using Finances.Contract;
    using Finances.Contract.Accounting;
    using Finances.Domain;

    /// <summary>
    /// The account Controller.
    /// </summary>
    [RoutePrefix("Account")]
    public class AccountController : ApiController, IAccountController
    {
        /// <summary>
        /// The service.
        /// </summary>
        private readonly IAccountService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public AccountController(IAccountService service)
        {
            this.service = service;
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
        [HttpPost]
        [Route("{owner:guid}/List")]
        public async Task<ActionResponse<AccountListResponse>> List(Guid owner, AccountListRequest input)
        {
            var result = new ActionResponse<AccountListResponse> { HasError = false };
            try
            {
                result.Results = await this.service.List(owner, input);
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        [HttpPost]
        [Route("{owner:guid}/AddCurrent")]
        public async Task<ActionResponse<Guid>> AddCurrentAccount(Guid owner, CurrentAccountIn input)
        {
            var result = new ActionResponse<Guid> { HasError = false };
            try
            {
                result.Results = await this.service.AddCurrentAccount(owner, input);
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        [HttpPost]
        [Route("{owner:guid}/AddSaving/{currentAccount:guid}")]
        public async Task<ActionResponse<Guid>> AddSavingAccount(Guid owner, Guid currentAccount, SavingAccountIn input)
        {
            var result = new ActionResponse<Guid> { HasError = false };
            try
            {
                result.Results = await this.service.AddSavingAccount(owner, currentAccount, input);
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }


        [HttpPost]
        [Route("{owner:guid}/AddLoan/{currentAccount:guid}")]
        public async Task<ActionResponse<Guid>> AddLoanAccount(Guid owner, Guid currentAccount, LoanAccountIn input)
        {
            var result = new ActionResponse<Guid> { HasError = false };
            try
            {
                result.Results = await this.service.AddLoanAccount(owner, currentAccount, input);
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
    }
}