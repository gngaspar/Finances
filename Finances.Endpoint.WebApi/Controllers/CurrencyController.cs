namespace Finances.Endpoint.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Finances.Contract.Banking;
    using Finances.Domain;

    /// <summary>
    /// The currency Controller
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController"/>
    /// <seealso cref="Finances.Domain.ICurrencyService"/>
    [RoutePrefix("Currency")]
    public class CurrencyController : ApiController, ICurrencyService
    {
        private readonly ICurrencyService _currencyService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyController"/> class.
        /// </summary>
        /// <param name="currencyService">The currency service.</param>
        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        /// <summary>
        /// Converts the specified amount.
        /// </summary>
        /// <param name="convert">The convert.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Convert")]
        public async Task<decimal> Convert(ConvertRequest convert)
        {
            return await _currencyService.Convert(convert);
        }

        /// <summary>
        /// Lists the specified request.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("List")]
        public async Task<CurrencyListResponse> List()
        {
            return await _currencyService.List();
        }

        [HttpPost]
        [Route("Update")]
        public async Task<bool> Update(List<CurrencyIn> input)
        {
            return await _currencyService.Update(input);
        }
    }
}