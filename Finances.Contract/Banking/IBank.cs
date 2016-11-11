namespace Finances.Contract.Banking
{
    using System.Threading.Tasks;

    public interface IBank
    {
        Task<ActionResponse> Add(BankIn bank);

        Task<ActionResponse> Edit(BankOut bank);

        Task<BankListResponse> List(BankListRequest request);
    }
}