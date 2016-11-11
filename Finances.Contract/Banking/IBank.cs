namespace Finances.Contract.Banking
{
    using System;
    using System.Threading.Tasks;

    public interface IBank
    {
        Task<ActionResponse> Add(BankIn bank);

        Task<ActionResponse> Edit(Guid code, BankIn bank);

        Task<BankListResponse> List(BankListRequest request);
    }
}