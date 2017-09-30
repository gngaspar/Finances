// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HumanClient.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the HumanClient type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Client
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Finances.Client.Common;
    using Finances.Contract;
    using Finances.Contract.Humans;

    /// <summary>
    /// The human client.
    /// </summary>
    internal class HumanClient : ClientBase, IHumanController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HumanClient"/> class.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        public HumanClient( IRestSender sender )
            : base( sender )
        {
        }

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
        public Task<HttpResponseMessage> Add( Guid code, HumanIn input )
        {
            throw new NotImplementedException();
        }

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
        public Task<HttpResponseMessage> Edit( Guid code, Guid human, HumanIn input )
        {
            throw new NotImplementedException();
        }

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
        public Task<HttpResponseMessage> List( Guid code, HumanListRequest input )
        {
            throw new NotImplementedException();
        }
    }
}