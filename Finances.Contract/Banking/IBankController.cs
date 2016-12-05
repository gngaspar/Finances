// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBankController.cs" company="Gng">
// Gng ggaspar@netcabo.pt
// </copyright>
// <summary>
//   The BankController interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Banking
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// The BankController interface.
    /// Basic interface that exposes actions to be done in the Bank elements.
    /// </summary>
    public interface IBankController
    {
        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="bank">
        /// The bank.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<ActionResponse<int>> Add(BankIn bank);

        /// <summary>
        /// The edit.
        /// </summary>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <param name="bank">
        /// The bank.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<ActionResponse<int>> Edit(Guid code, BankIn bank);

        /// <summary>
        /// The list.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<ActionResponse<BankListResponse>> List(BankListRequest input);
    }
}