namespace Finances.Endpoint.WebApi.ApiControllers
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;

    using Finances.Contract;
    using Finances.Contract.Banking;
    using Finances.Domain;

    /// <summary>
    /// The Controller for banking
    /// </summary>
    [RoutePrefix("Bank")]
    public class BankController : BaseController, IBankController
    {
        /// <summary>
        /// The bank service.
        /// </summary>
        private readonly IBankService bankService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankController"/> class.
        /// </summary>
        /// <param name="bankService">
        /// The bank service.
        /// </param>
        public BankController(IBankService bankService)
        {
            this.bankService = bankService;
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="bank">
        /// The bank.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        [Route("Add")]
        [ResponseType(typeof(ActionResponse<Guid>))]
        public async Task<HttpResponseMessage> Add(BankIn bank)
        {
            return await this.ProcessActionAsync(bank, this.bankService.Add);
        }

        /// <summary>
        /// The edit.
        /// </summary>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <param name="bank">
        /// The bank.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        [Route("{code:guid}/Edit")]
        public async Task<ActionResponse<bool>> Edit(Guid code, BankIn bank)
        {
            var response = new ActionResponse<bool> { HasError = false, Results = false };
            try
            {
                response.Results = await this.bankService.Edit(code, bank);
            }
            catch (Exception ex)
            {
                response.HasError = true;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// The list.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        [Route("List")]
        [ResponseType(typeof(ActionResponse<BankListResponse>))]
        public async Task<HttpResponseMessage> List(BankListRequest request)
        {
            return await this.ProcessActionAsync(request, this.bankService.List);
        }
    }
}