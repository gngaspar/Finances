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
        private readonly ICurrencyService _currencyService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyController"/> class.
        /// </summary>
        /// <param name="currencyService">The currency service.</param>
        public CurrencyController(ICurrencyService currencyService)
        {
            this._currencyService = currencyService;
        }

        /// <summary>
        /// Converts the specified amount.
        /// </summary>
        /// <param name="convert">The convert.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Convert")]
        public async Task<ActionResponse<decimal>> Convert(ConvertRequest convert)
        {
            var result = new ActionResponse<decimal> { HasError = false };
            try
            {
                result.Results = await this._currencyService.Convert(convert);
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
        /// <returns></returns>
        [HttpPost]
        [Route("List")]
        public async Task<ActionResponse<CurrencyListResponse>> List()
        {
            var result = new ActionResponse<CurrencyListResponse> { HasError = false };
            try
            {
                result.Results = await this._currencyService.List();
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Update")]
        public async Task<ActionResponse<int>> Update(List<CurrencyIn> input)
        {
            var result = new ActionResponse<int> { HasError = false };
            try
            {
                result.Results = await this._currencyService.Update(input);
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