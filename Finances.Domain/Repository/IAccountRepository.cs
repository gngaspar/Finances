namespace Finances.Domain.Repository
{
    using System;
    using System.Threading.Tasks;

    using Finances.Contract.Accounting;

    /// <summary>
    /// The AccountRepository interface.
    /// </summary>
    public interface IAccountRepository : IDisposable
    {
        /// <summary>
        /// The list.
        /// </summary>
        /// <param name="owner">
        /// The owner of the portofolio.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<AccountListResponse> List(Guid owner, AccountListRequest input);
    }
}