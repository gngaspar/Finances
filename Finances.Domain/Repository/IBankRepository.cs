namespace Finances.Domain.Repository
{
    using System;
    using System.Threading.Tasks;
    using Finances.Contract;
    using Finances.Contract.Banking;

    public interface IBankRepository : IDisposable
    {
        Task<ActionResponse> Add(BankIn parameters);

        Task<ActionResponse> Edit(BankIn parameters);

        Task<BankOut> Get(Guid parameters);

        Task<BankListResponse> List(BankListRequest parameters);
    }
}