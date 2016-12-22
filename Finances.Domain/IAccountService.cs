namespace Finances.Domain
{
    using System;
    using System.Threading.Tasks;

    using Finances.Contract;
    using Finances.Contract.Accounting;

    public interface IAccountService
    {
        Task<AccountListResponse> List(Guid owner, AccountListRequest input);


        Task<Guid> AddCurrentAccount(Guid owner, CurrentAccountIn input);

        Task<Guid> AddSavingAccount(Guid owner, Guid currentAccount, SavingAccountIn input);

        Task<Guid> AddLoanAccount(Guid owner, Guid currentAccount, LoanAccountIn input);

        Task<LoanAccountOut> GetLoanDetails(Guid owner, Guid account);

        Task<SavingAccountOut> GetSavingDetails(Guid owner, Guid account);

        Task<CurrentAccountOut> GetCurrentDetails(Guid owner, Guid account);
    }
}