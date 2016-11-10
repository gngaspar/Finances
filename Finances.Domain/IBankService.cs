namespace Finances.Domain
{
    using System.Threading.Tasks;
    using Finances.Contract;
    using Finances.Contract.Banking;

    public interface IBankService
    {
        Task<ActionResponse> Add(BankIn request);

        Task<ActionResponse> Edit(BankIn request);

        Task<BankListResponse> List(BankListRequest request);
    }
}