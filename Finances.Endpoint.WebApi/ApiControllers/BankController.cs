namespace Finances.Endpoint.WebApi.ApiControllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Http;

    using Finances.Contract;
    using Finances.Contract.Banking;
    using Finances.Domain;

    /// <summary>
    /// The Controller for banking
    /// </summary>
    [RoutePrefix("Bank")]
    public class BankController : ApiController, IBankController
    {
        private readonly IBankService _bankService;

        /// <summary>
        /// The contructor for Ninject
        /// </summary>
        /// <param name="bankService">The Banking Service interface</param>
        public BankController(IBankService bankService)
        {
            this._bankService = bankService;
        }

        /// <summary>
        /// Adds the specified bank.
        /// </summary>
        /// <param name="bank">The bank.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResponse<int>> Add(BankIn bank)
        {
            var response = new ActionResponse<int> { HasError = false };
            try
            {
                response.Results = await this._bankService.Add(bank);
            }
            catch (Exception ex)
            {
                response.HasError = true;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// Edits the specified bank.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="bank">The bank.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{code:guid}/Edit")]
        public async Task<ActionResponse<int>> Edit(Guid code, BankIn bank)
        {
            var response = new ActionResponse<int> { HasError = false };
            try
            {
                response.Results = await this._bankService.Edit(code, bank);
            }
            catch (Exception ex)
            {
                response.HasError = true;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// Lists the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("List")]
        public async Task<ActionResponse<BankListResponse>> List(BankListRequest request)
        {
            var response = new ActionResponse<BankListResponse> { HasError = false };
            try
            {
                response.Results = await this._bankService.List(request);
            }
            catch (Exception ex)
            {
                response.HasError = true;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
    }
}