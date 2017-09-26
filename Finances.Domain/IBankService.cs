// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBankService.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The Bank service actions methods.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Domain
{
    using System;
    using System.Threading.Tasks;
    using Finances.Contract.Banking;
    using Finances.Domain.Wrappers;

    /// <summary>
    /// The Bank service actions methods.
    /// </summary>
    public interface IBankService
    {
        /// <summary>
        /// Adds the specified bank.
        /// </summary>
        /// <param name="bank">
        /// The bank.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<Guid> Add( BankIn bank );

        /// <summary>
        /// Edits the specified bank.
        /// </summary>
        /// <param name="bank">
        /// The bank.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<bool> Edit( BankEdit bank );

        /// <summary>
        /// Lists the specified request.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<BankListResponse> List( BankListRequest request );
    }
}