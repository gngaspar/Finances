// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IHumanController.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the IHumanController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Humans
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Finances.Contract.Banking;

    /// <summary>
    /// The HumanController interface.
    /// </summary>
    public interface IHumanController
    {
        /// <summary>
        /// The list.
        /// </summary>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<HttpResponseMessage> List( Guid code, HumanListRequest input );

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<HttpResponseMessage> Add( Guid code, HumanIn input );

        /// <summary>
        /// The edit.
        /// </summary>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <param name="human">
        /// The human.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<HttpResponseMessage> Edit( Guid code, Guid human, HumanIn input );
    }
}