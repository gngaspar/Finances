// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICurrencyRepository.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The CurrencyRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Domain.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Finances.Contract.Banking;

    /// <summary>
    /// The CurrencyRepository interface.
    /// </summary>
    public interface ICurrencyRepository : IDisposable
    {
        /// <summary>
        /// The copy to history.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<int> CopyToHistory();

        /// <summary>
        /// The get the history last day.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<DateTime> GetTheHistoryLastDay();

        /// <summary>
        /// The list.
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
    }
}