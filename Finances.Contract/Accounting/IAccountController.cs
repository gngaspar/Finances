﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAccountController.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The AccountController interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Accounting
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// The AccountController interface.
    /// </summary>
    public interface IAccountController
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
        Task<HttpResponseMessage> List( Guid owner, AccountListRequest input );

        /// <summary>
        /// The get get current details.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="account">
        /// The account.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<HttpResponseMessage> GetCurrentDetails( Guid owner, Guid account );

        Task<HttpResponseMessage> GetLoanDetails( Guid owner, Guid account );

        Task<HttpResponseMessage> GetSavingDetails( Guid owner, Guid account );
    }
}