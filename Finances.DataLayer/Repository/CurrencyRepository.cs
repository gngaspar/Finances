namespace Finances.DataLayer.Repository
{
    using System.Threading.Tasks;
    using Finances.Contract.Banking;
    using Finances.Domain.Repository;

    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly BankingDbContext context;

        public CurrencyRepository()
        {
            this.context = new BankingDbContext();
        }

        internal CurrencyRepository(BankingDbContext bankingDbContext)
        {
            this.context = bankingDbContext;
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        public Task<CurrencyListResponse> List()
        {
            throw new System.NotImplementedException();
        }
    }
}