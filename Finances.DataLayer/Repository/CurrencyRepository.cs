namespace Finances.DataLayer.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using Finances.Contract.Banking;
    using Finances.DataLayer.Extension;
    using Finances.Domain.Banking;
    using Finances.Domain.Repository;

    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly BankingDbContext _context;

        public CurrencyRepository()
        {
            this._context = new BankingDbContext();
        }

        internal CurrencyRepository(BankingDbContext bankingDbContext)
        {
            this._context = bankingDbContext;
        }

        public async Task<int> CopyToHistory()
        {
            var queryResult = await this._context.Currencies.Where(i => i.ReasonToOneEuro != 0).Select(c => new
            {
                c.ReasonToOneEuro,
                c.Currency
            }).ToListAsync();

            this._context.CurrencyHistory.AddRange(queryResult.Select(c => new CurrencyHistoryEntity
            {
                ReasonToOneEuro = c.ReasonToOneEuro,
                Currency = c.Currency,
                CreatedAtDay = DateTime.Now.AddDays(-1)
            }));

            return await this._context.SaveChangesAsync();
        }

        public void Dispose()
        {
            this._context.Dispose();
        }

        public async Task<DateTime> GetTheHistoryLastDay()
        {
            var hasAny = await _context.CurrencyHistory.AnyAsync();

            if (!hasAny)
            {
                return DateTime.Now.AddYears(-1);
            }

            return await this._context.CurrencyHistory.MaxAsync(i => i.CreatedAtDay);
        }

        public async Task<CurrencyListResponse> List()
        {
            var queryResult = await this._context.Currencies.CountAsync();

            var list = await this._context.Currencies.OrderBy(o => o.Order)
                        .Select(currency => new CurrencyOut
                        {
                            Name = currency.Name,
                            Code = currency.Currency,
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

        public async Task<int> Update(List<CurrencyIn> input)
        {
            var myList = await this._context.Currencies.ToListAsync();
            var myCounter = myList.Count + 1;

            var listEntities = new List<CurrencyEntity>();

            foreach (var currency in input.OrderBy(i => i.Code))
            {
                currency.Code = currency.Code.ToUpper();

                var currencyEntity = new CurrencyEntity
                {
                    Currency = currency.Code,
                    ReasonToOneEuro = currency.ReasonToOneEuro
                };

                var oldCurreny = myList.FirstOrDefault(i => i.Currency == currency.Code);

                currencyEntity.Order = oldCurreny?.Order ?? (currencyEntity.Order = myCounter);
                currencyEntity.Name = (oldCurreny != null) ? oldCurreny.Name : currency.Code;
                currencyEntity.ChangeAt = DateTime.Now;

                _context.SeedAddOrUpdate(p => p.Currency, p => new { p.ReasonToOneEuro, p.ChangeAt },
                    currencyEntity
                );

                myCounter = myCounter + 1;
            }

            return await this._context.SaveChangesAsync();
        }
    }
}