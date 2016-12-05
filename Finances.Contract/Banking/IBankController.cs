namespace Finances.Contract.Banking
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// The BankController interface.
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
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<ActionResponse<BankListResponse>> List(BankListRequest request);
    }
}