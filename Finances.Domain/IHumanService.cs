// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IHumanService.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The HumanService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Domain
{
    using System;
    using System.Threading.Tasks;

    using Finances.Contract.Humans;
    using Finances.Domain.Wrappers;

    /// <summary>
    /// The HumanService interface.
    /// </summary>
    public interface IHumanService
    {
        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<Guid> Add( Guid owner, HumanIn input );

        /// <summary>
        /// The edit.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<bool> Edit( Guid owner, HumanEdit input );

        /// <summary>
        /// The list.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<HumanListResponse> List( Guid owner, HumanListRequest input );
    }
}