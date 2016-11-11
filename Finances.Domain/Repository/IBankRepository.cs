namespace Finances.Domain.Repository
{
    using System;
    using System.Threading.Tasks;
    using Finances.Contract;
    using Finances.Contract.Banking;

    /// <summary>
    /// The Bank database actions methods representantion.
    /// </summary>
    /// <seealso cref="System.IDisposable"/>
    public interface IBankRepository : IDisposable
    {
        /// <summary>
        /// Adds the specified bank.
        /// </summary>
        /// <param name="bank">The bank.</param>
        /// <returns>The action response.</returns>
        Task<ActionResponse> Add(BankIn bank);

        /// <summary>
        /// Edits the specified bank.
        /// </summary>
        /// <param name="bank">The bank.</param>
        /// <returns>The action response.</returns>
        Task<ActionResponse> Edit(BankIn bank);

        /// <summary>
        /// Gets the specified code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>The Bank if found</returns>
        Task<BankOut> Get(Guid code);

        /// <summary>
        /// Gets the by swift.
        /// </summary>
        /// <param name="swift">The swift.</param>
        /// <returns>The Bank if found</returns>
        Task<BankOut> GetBySwift(string swift);

        /// <summary>
        /// Gets the lists the of banks.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The list of Banks</returns>
        Task<BankListResponse> List(BankListRequest parameters);
    }
}