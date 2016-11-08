namespace Finances.Management
{
    using System.Threading.Tasks;
    using Finances.Contract.Banking;
    using Finances.Domain;
    using Finances.Domain.Repository;

    public class BankService : IBankService
    {
        private readonly IBankRepository bankRepository;

        public BankService(
            IBankRepository bankRepository
            )
        {
            this.bankRepository = bankRepository;
        }

        public async Task<BankListResponse> BankList(BankListRequest request)
        {
            return await this.bankRepository.GetList(request);
        }
    }
}