// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRestSender.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The RestSender interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Client.Common
{
    using System.Threading.Tasks;

    /// <summary>
    /// The RestSender interface.
    /// </summary>
    public interface IRestSender
    {
        /// <summary>
        /// The call service async.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<IRestResult> CallServiceAsync( IRestMessageContext message );
    }
}