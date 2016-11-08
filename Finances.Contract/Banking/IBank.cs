namespace Finances.Contract.Banking
{
    using System.Threading.Tasks;

    public interface IBank
    {
        Task<BankListResponse> BankList(BankListRequest request);
    }
}