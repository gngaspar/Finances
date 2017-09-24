// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICurrencyController.cs" company="Gng">
// Gng ggaspar@netcabo.pt
// </copyright>
// <summary>
// The Currency interface
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Banking
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// The Currency interface
    /// </summary>
    public interface ICurrencyController
    {
        /// <summary>
        /// The convert action.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<HttpResponseMessage> Convert(ConvertRequest input);

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
        Task<HttpResponseMessage> ConvertString(string fromCurrency, string toCurrency, decimal amount);

        /// <summary>
        /// The list.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<HttpResponseMessage> List();

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<HttpResponseMessage> Update(List<CurrencyIn> input);
    }
}