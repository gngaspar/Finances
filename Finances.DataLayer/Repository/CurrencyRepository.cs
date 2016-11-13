namespace Finances.DataLayer.Repository
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using Finances.Contract.Banking;
    using Finances.Domain.Banking;
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

        public async Task<bool> CopyToHistory()
        {
            var queryResult = await this.context.Currencies.Select(c => new
            {
                c.ReasonToOneEuro,
                c.Currency,
                CreatedAtDay = c.ChangeAt ?? DateTime.Now
            }).ToListAsync();

            this.context.CurrencyHistory.AddRange(queryResult.Select(c => new CurrencyHistoryEntity
            {
                ReasonToOneEuro = c.ReasonToOneEuro,
                Currency = c.Currency,
                CreatedAtDay = c.CreatedAtDay
            }));

            var myint = await this.context.SaveChangesAsync();
            return myint == 0;
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