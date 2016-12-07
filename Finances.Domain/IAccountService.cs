namespace Finances.Domain
{
    using System;
    using System.Threading.Tasks;

    using Finances.Contract.Accounting;

    public interface IAccountService
    {
        Task<AccountListResponse> List(Guid owner, AccountListRequest input);
    }
}