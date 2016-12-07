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
        [Route("{code:guid}/List")]
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
    }
}