namespace Finances.Contract.Accounting
{
    using System;
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
        Task<ActionResponse<AccountListResponse>> List(Guid owner, AccountListRequest input);
    }
}