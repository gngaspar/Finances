// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IParameterizationsService.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the IParameterizationsService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Domain
{
    using System;
    using System.Threading.Tasks;

    using Finances.Contract.Parameterizations;

    /// <summary>
    /// The ParameterizationsService interface.
    /// </summary>
    public interface IParameterizationsService
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