// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPlasticRepository.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The Plastic Repository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Domain.Repository
{
    using System;
    using System.Threading.Tasks;

    using Finances.Contract.Plastics;

    /// <summary>
    /// The Plastic Repository interface.
    /// </summary>
    public interface IPlasticRepository : IDisposable
    {
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
        Task<CardListResponse> List( Guid owner, CardListRequest input );
    }
}
