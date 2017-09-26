// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrencyClient.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the CurrencyClient type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Client
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Finances.Client.Common;
    using Finances.Contract;
    using Finances.Contract.Banking;

    /// <summary>
    /// The currency client.
    /// </summary>
    public class CurrencyClient : ClientBase, ICurrencyController
    {
        /// <summary>
        /// The url prefix.
        /// </summary>
        private const string UrlPrefix = "/Currency/";

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyClient"/> class.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        public CurrencyClient( IRestSender sender ) : base( sender )
        {
        }

        ////public Task<decimal> Convert(ConvertRequest convert)
        ////{
        ////    throw new System.NotImplementedException();
        ////}

        ////public Task<CurrencyListResponse> List()
        ////{
        ////    throw new System.NotImplementedException();
        ////}

        ////public async Task<ActionResponse> Update(List<CurrencyIn> input)
        ////{
        ////    var context = CreateContextXml();

        ////    context.HttpMethod = HttpMethod.Post;
        ////    context.ServiceMethod = ServiceMethod.Update;
        ////    context.UrlPath = UrlPrefix + "Update";

        ////    return await this.ExecuteSender<List<CurrencyIn>, ActionResponse>(input, context);
        ////}

        /// <summary>
        /// The convert.
        /// </summary>
        /// <param name="convert">
        /// The object to convert.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<HttpResponseMessage> Convert( ConvertRequest convert )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The convert string.
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
        public Task<HttpResponseMessage> ConvertString( string fromCurrency, string toCurrency, decimal amount )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The list.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<HttpResponseMessage> ICurrencyController.List()
        {
            throw new NotImplementedException();
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
        Task<HttpResponseMessage> ICurrencyController.Update( List<CurrencyIn> input )
        {
            throw new NotImplementedException();
        }
    }
}