namespace Finances.Client
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Finances.Client.Common;
    using Finances.Contract;
    using Finances.Contract.Accounting;

    public class AccountClient : ClientBase, IAccountController
    {
        public AccountClient(IRestSender sender)
            : base(sender)
        {
        }


        public Task<ActionResponse<CurrentAccountOut>> GetCurrentAccount(Guid owner, Guid account)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResponse<LoanAccountOut>> GetLoanAccount(Guid owner, Guid account)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResponse<SavingAccountOut>> GetSavingAccount(Guid owner, Guid account)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResponse<Guid>> AddCurrentAccount(Guid owner, CurrentAccountIn input)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResponse<Guid>> AddSavingAccount(Guid owner, Guid currentAccount, SavingAccountIn input)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResponse<Guid>> AddLoanAccount(Guid owner, Guid currentAccount, LoanAccountIn input)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> List(Guid owner, AccountListRequest input)
        {
            throw new NotImplementedException();
        }
    }
}