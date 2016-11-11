namespace Finances.Endpoint.WebApi.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Finances.Contract;
    using Finances.Contract.Banking;
    using Finances.Domain;

    [RoutePrefix("Bank")]
    public class BankController : ApiController, IBankService
    {
        private readonly IBankService _bankervice;

        public BankController(IBankService bankervice)
        {
            _bankervice = bankervice;
        }

        /// <summary>
        /// Adds the specified bank.
        /// </summary>
        /// <param name="bank">The bank.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResponse> Add(BankIn bank)
        {
            return await _bankervice.Add(bank);
        }

        /// <summary>
        /// Edits the specified bank.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="bank">The bank.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{code:guid}/Edit")]
        public async Task<ActionResponse> Edit(Guid code, BankIn bank)
        {
            return await _bankervice.Edit(code, bank);
        }

        /// <summary>
        /// Lists the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("List")]
        public async Task<BankListResponse> List(BankListRequest request)
        {
            return await _bankervice.List(request);
        }
    }
}