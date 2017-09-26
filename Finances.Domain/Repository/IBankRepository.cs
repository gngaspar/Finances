// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBankRepository.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The Bank database actions methods representation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Domain.Repository
{
    using System;
    using System.Threading.Tasks;
    using Finances.Contract.Banking;

    /// <summary>
    /// The Bank database actions methods representation.
    /// </summary>
    /// <seealso cref="System.IDisposable"/>
    public interface IBankRepository : IDisposable
    {
        /// <summary>
        /// Adds the specified bank.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="bank">The bank.</param>
        /// <returns>The value response.</returns>
        Task<int> Add( Guid code, BankIn bank );

        /// <summary>
        /// Edits the specified bank.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="bank">The bank.</param>
        /// <returns>The action response.</returns>
        Task<int> Edit( Guid code, BankIn bank );

        /// <summary>
        /// Gets if exists the bank by code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>The boolean if found.</returns>
        Task<bool> ExistsByCode( Guid code );

        /// <summary>
        /// Gets if exists the bank by swift.
        /// </summary>
        /// <param name="swift">The swift.</param>
        /// <returns>The boolean if found.</returns>
        Task<bool> ExistsBySwift( string swift );

        /// <summary>
        /// Gets the lists the of banks.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The list of Banks.</returns>
        Task<BankListResponse> List( BankListRequest parameters );

        /// <summary>
        /// This the swift exists in other bank.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="swift">The swift.</param>
        /// <returns>The boolean if found.</returns>
        Task<bool> ThisSwiftExistsInOther( Guid code, string swift );
    }
}