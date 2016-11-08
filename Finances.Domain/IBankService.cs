namespace Finances.Domain
{
    using System.Threading.Tasks;
    using Finances.Contract.Banking;

    public interface IBankService
    {
        Task<BankListResponse> BankList(BankListRequest request);
    }
}