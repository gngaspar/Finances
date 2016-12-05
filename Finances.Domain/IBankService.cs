﻿namespace Finances.Domain
{
    using System;
    using System.Threading.Tasks;
    using Finances.Contract;
    using Finances.Contract.Banking;

    /// <summary>
    /// The Bank service actions methods representantion.
    /// </summary>
    public interface IBankService
    {
        /// <summary>
        /// Adds the specified bank.
        /// </summary>
        /// <param name="bank">The bank.</param>
        /// <returns></returns>
        Task<int> Add(BankIn bank);

        /// <summary>
        /// Edits the specified bank.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="bank">The bank.</param>
        /// <returns></returns>
        Task<int> Edit(Guid code, BankIn bank);

        /// <summary>
        /// Lists the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<BankListResponse> List(BankListRequest request);
    }
}