namespace Finances.Endpoint.WebApi.ApiControllers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;

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
        [ResponseType(typeof(ActionResponse<decimal>))]
        public async Task<HttpResponseMessage> Convert(ConvertRequest convert)
        {
            var stataus = HttpStatusCode.OK;
            var result = new ActionResponse<decimal> { HasError = false };
            try
            {
                result.Results = await this.currencyService.Convert(convert);
            }
            catch (Exception ex)
            {
                stataus = HttpStatusCode.InternalServerError;
                result.HasError = true;
                result.ErrorMessage = ex.Message;
            }

            return this.Request.CreateResponse(stataus, result);
        }

        /// <summary>
        /// The convert.
        /// </summary>
        /// <param name="toCurrency">
        /// The to currency.
        /// </param>
        /// <param name="fromCurrency">
        /// The from currency.
        /// </param>
        /// <param name="amount">
        /// The amount.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        [Route("Convert/{toCurrency}/{fromCurrency}/{amount}")]
        [ResponseType(typeof(ActionResponse<decimal>))]
        public async Task<HttpResponseMessage> ConvertString(string toCurrency, string fromCurrency, decimal amount)
        {
            var request = new ConvertRequest { Amount = amount, FromCurrency = fromCurrency, ToCurrency = toCurrency };

            return await this.Convert(request);
        }

        /// <summary>
        /// Lists the specified request.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        [Route("List")]
        [ResponseType(typeof(ActionResponse<CurrencyListResponse>))]
        public async Task<HttpResponseMessage> List()
        {
            var stataus = HttpStatusCode.OK;
            var result = new ActionResponse<CurrencyListResponse> { HasError = false };
            try
            {
                result.Results = await this.currencyService.List();
            }
            catch (Exception ex)
            {
                stataus = HttpStatusCode.InternalServerError;
                result.HasError = true;
                result.ErrorMessage = ex.Message;
            }

            return this.Request.CreateResponse(stataus, result);
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