namespace Finances.Management
{
    using System.Threading.Tasks;
    using Finances.Contract;
    using Finances.Contract.Banking;
    using Finances.Domain;
    using Finances.Domain.Repository;

    public class BankService : IBankService
    {
        private readonly IBankRepository bankRepository;

        public BankService(IBankRepository bankRepository)
        {
            this.bankRepository = bankRepository;
        }

        public Task<ActionResponse> Add(BankIn request)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResponse> Edit(BankIn request)
        {
            throw new System.NotImplementedException();
        }

        public async Task<BankListResponse> List(BankListRequest request)
        {
            return await this.bankRepository.List(request);
        }
    }
}