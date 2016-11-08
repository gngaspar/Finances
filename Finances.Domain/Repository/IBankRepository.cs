namespace Finances.Domain.Repository
{
    using System;
    using System.Threading.Tasks;
    using Finances.Contract.Banking;

    public interface IBankRepository : IDisposable
    {
        Task<BankListResponse> GetList(BankListRequest parameters);
    }
}