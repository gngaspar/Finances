// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrencyController.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The currency Controller
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Endpoint.WebApi.ApiControllers
{
    using System.Collections.Generic;
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
    [RoutePrefix( "Currency" )]
    public class CurrencyController : BaseController, ICurrencyController
    {
        /// <summary>
        /// The currency service.
        /// </summary>
        private readonly ICurrencyService currencyService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyController"/> class.
        /// </summary>
        /// <param name="currencyService">The currency service.</param>
        public CurrencyController( ICurrencyService currencyService )
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
        [Route( "Convert" )]
        [ResponseType( typeof( ActionResponse<decimal> ) )]
        public async Task<HttpResponseMessage> Convert( ConvertRequest convert )
        {
            return await this.ProcessActionAsync( convert, this.currencyService.Convert );
        }

        /// <summary>
        /// The convert.
        /// </summary>  
        /// <param name="fromCurrency">
        /// The from currency.
        /// </param>
        /// <param name="toCurrency">
        /// The to currency.
        /// </param>
        /// <param name="amount">
        /// The amount.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet]
        [Route( "Convert/{fromCurrency}/{toCurrency}/{amount}" )]
        [ResponseType( typeof( ActionResponse<decimal> ) )]
        public async Task<HttpResponseMessage> ConvertString( string fromCurrency, string toCurrency, decimal amount )
        {
            var request = new ConvertRequest { Amount = amount, FromCurrency = fromCurrency, ToCurrency = toCurrency };

            return await this.ProcessActionAsync( request, this.currencyService.Convert );
        }

        /// <summary>
        /// Lists the specified request.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet]
        [Route( "List" )]
        [ResponseType( typeof( ActionResponse<CurrencyListResponse> ) )]
        public async Task<HttpResponseMessage> List()
        {
            return await this.ProcessActionAsync( this.currencyService.List );
        }

        /// <summary>
        /// The history.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        [Route( "GetHistory" )]
        [ResponseType( typeof( ActionResponse<HistoryListResponse> ) )]
        public async Task<HttpResponseMessage> GetHistory( HistoryListRequest request )
        {
            return await this.ProcessActionAsync( request, this.currencyService.History );
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
        [Route( "Update" )]
        [ResponseType( typeof( ActionResponse<int> ) )]
        public async Task<HttpResponseMessage> Update( List<CurrencyIn> input )
        {
            return await this.ProcessActionAsync( input, this.currencyService.Update );
        }
    }
}