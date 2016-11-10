namespace Finances.Contract.Banking
{
    using System.Threading.Tasks;

    public interface IBank
    {
        Task<ActionResponse> Add(BankIn request);

        Task<ActionResponse> Edit(BankIn request);

        Task<BankListResponse> List(BankListRequest request);
    }
}