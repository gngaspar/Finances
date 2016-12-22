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

        Task<ActionResponse<CurrentAccountOut>> GetCurrentAccount(Guid owner, Guid account);

        Task<ActionResponse<LoanAccountOut>> GetLoanAccount(Guid owner, Guid account);

        Task<ActionResponse<SavingAccountOut>> GetSavingAccount(Guid owner, Guid account);

        Task<ActionResponse<Guid>> AddCurrentAccount(Guid owner, CurrentAccountIn input);

        Task<ActionResponse<Guid>> AddSavingAccount(Guid owner, Guid currentAccount, SavingAccountIn input);

        Task<ActionResponse<Guid>> AddLoanAccount(Guid owner, Guid currentAccount, LoanAccountIn input);
    }
}