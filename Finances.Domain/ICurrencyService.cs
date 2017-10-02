// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICurrencyService.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The CurrencyService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Domain
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Finances.Contract;
    using Finances.Contract.Banking;

    /// <summary>
    /// The CurrencyService interface.
    /// </summary>
    public interface ICurrencyService
    {
        /// <summary>
        /// Converts the specified amount.
        /// </summary>
        /// <param name="convert">
        /// The convert.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<decimal> Convert( ConvertRequest convert );

        /// <summary>
        /// Lists the specified request.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<CurrencyListResponse> List();

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<int> Update( List<CurrencyIn> input );

        /// <summary>
        /// The history.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<HistoryListResponse> GetHistory( HistoryListRequest request );
    }
}