// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBankController.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The BankController interface.
//   Basic interface that exposes actions to be done in the Bank elements.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Banking
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// The BankController interface.
    /// Basic interface that exposes actions to be done in the Bank elements.
    /// </summary>
    public interface IBankController
    {
        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="bank">
        /// The bank.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<HttpResponseMessage> Add(BankIn bank);

        /// <summary>
        /// The edit.
        /// </summary>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <param name="bank">
        /// The bank.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<HttpResponseMessage> Edit(Guid code, BankIn bank);

        /// <summary>
        /// The list.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<HttpResponseMessage> List(BankListRequest input);
    }
}