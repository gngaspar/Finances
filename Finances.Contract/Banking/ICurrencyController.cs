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
        Task<ActionResponse<decimal>> Convert(ConvertRequest input);

        /// <summary>
        /// The list.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<ActionResponse<CurrencyListResponse>> List();

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<ActionResponse<int>> Update(List<CurrencyIn> input);
    }
}