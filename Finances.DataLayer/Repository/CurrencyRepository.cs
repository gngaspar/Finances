namespace Finances.DataLayer.Repository
{
    using System.Data.Entity;
    using System.Linq;
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

        public async Task<CurrencyListResponse> List()
        {
            var queryResult = await this.context.Currencies.CountAsync();

            var list = await this.context.Currencies.OrderBy(o => o.Order)
                        .Select(currency => new CurrencyOut
                        {
                            Name = currency.Name,
                            CurrencyCode = currency.Currency,
                            ReasonToOneEuro = currency.ReasonToOneEuro,
                            ChangeAt = currency.ChangeAt,
                        }).ToListAsync();

            var result = new CurrencyListResponse
            {
                NumberOfItems = queryResult,
                Data = list
            };

            return result;
        }
    }
}