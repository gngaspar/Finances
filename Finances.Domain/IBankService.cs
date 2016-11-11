namespace Finances.Domain
{
    using System.Threading.Tasks;
    using Finances.Contract;
    using Finances.Contract.Banking;

    /// <summary>
    /// The Bank service actions methods representantion.
    /// </summary>
    public interface IBankService
    {
        /// <summary>
        /// Adds the specified bank.
        /// </summary>
        /// <param name="bank">The bank.</param>
        /// <returns></returns>
        Task<ActionResponse> Add(BankIn bank);

        /// <summary>
        /// Edits the specified bank.
        /// </summary>
        /// <param name="bank">The bank.</param>
        /// <returns></returns>
        Task<ActionResponse> Edit(BankIn bank);

        /// <summary>
        /// Lists the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<BankListResponse> List(BankListRequest request);
    }
}