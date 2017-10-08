// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPlasticController.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The PlasticController interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Plastics
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// The PlasticController interface.
    /// </summary>
    public interface IPlasticController
    {
        /// <summary>
        /// The list.
        /// </summary>
        /// <param name="owner">
        /// The owner guid.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<HttpResponseMessage> List( Guid owner, CardListRequest input );
    }
}
