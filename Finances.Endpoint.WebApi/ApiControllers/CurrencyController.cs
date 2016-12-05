namespace Finances.Endpoint.WebApi.ApiControllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Http;

    using Finances.Contract;
    using Finances.Contract.Banking;
    using Finances.Domain;

    /// <summary>
    /// The currency Controller
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController"/>
    /// <seealso cref="Finances.Domain.ICurrencyService"/>
    [RoutePrefix("Currency")]
    public class CurrencyController : ApiController, ICurrencyController
    {
        /// <summary>
        /// The currency service.
        /// </summary>
        private readonly ICurrencyService currencyService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyController"/> class.
        /// </summary>
        /// <param name="currencyService">The currency service.</param>
        public CurrencyController(ICurrencyService currencyService)
        {
            this.currencyService = currencyService;
        }

        /// <summary>
        /// Converts the specified amount.
        /// </summary>
        /// <param name="convert">
        /// The convert.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        [Route("Convert")]
        public async Task<ActionResponse<decimal>> Convert(ConvertRequest convert)
        {
            var result = new ActionResponse<decimal> { HasError = false };
            try
            {
                result.Results = await this.currencyService.Convert(convert);
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// Lists the specified request.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        [Route("List")]
        public async Task<ActionResponse<CurrencyListResponse>> List()
        {
            var result = new ActionResponse<CurrencyListResponse> { HasError = false };
            try
            {
                result.Results = await this.currencyService.List();
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        [Route("Update")]
        public async Task<ActionResponse<int>> Update(List<CurrencyIn> input)
        {
            var result = new ActionResponse<int> { HasError = false };
            try
            {
                result.Results = await this.currencyService.Update(input);
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