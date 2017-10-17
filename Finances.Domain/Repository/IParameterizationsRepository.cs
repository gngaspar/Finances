// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IParameterizationsRepository.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the IParameterizationsRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Domain.Repository
{
    using System;
    using System.Threading.Tasks;

    using Finances.Contract.Parameterizations;
    using Finances.Contract.Plastics;

    /// <summary>
    /// The ParameterizationsRepository interface.
    /// </summary>
    public interface IParameterizationsRepository : IDisposable
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
        Task<int> Add( Guid owner, ParameterizationIn input );
    }
}
