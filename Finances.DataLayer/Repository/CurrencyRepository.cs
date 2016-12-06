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

    /// <summary>
    /// The currency repository.
    /// </summary>
    public class CurrencyRepository : ICurrencyRepository
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly BankingDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyRepository"/> class.
        /// </summary>
        public CurrencyRepository()
        {
            this.context = new BankingDbContext();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyRepository"/> class.
        /// </summary>
        /// <param name="bankingDbContext">
        /// The banking database context.
        /// </param>
        internal CurrencyRepository(BankingDbContext bankingDbContext)
        {
            this.context = bankingDbContext;
        }

        /// <summary>
        /// The copy to history.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<int> CopyToHistory()
        {
            var queryResult = await this.context.Currencies.Where(i => i.ReasonToOneEuro != 0).Select(c => new
            {
                c.ReasonToOneEuro,
                c.Currency
            }).ToListAsync();

            this.context.CurrencyHistory.AddRange(queryResult.Select(c => new CurrencyHistoryEntity
            {
                ReasonToOneEuro = c.ReasonToOneEuro,
                Currency = c.Currency,
                CreatedAtDay = DateTime.Now.AddDays(-1)
            }));

            return await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.context.Dispose();
        }

        /// <summary>
        /// The get the history last day.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<DateTime> GetTheHistoryLastDay()
        {
            var hasAny = await this.context.CurrencyHistory.AnyAsync();

            if (!hasAny)
            {
                return DateTime.Now.AddYears(-1);
            }

            return await this.context.CurrencyHistory.MaxAsync(i => i.CreatedAtDay);
        }

        /// <summary>
        /// The list.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<CurrencyListResponse> List()
        {
            var queryResult = await this.context.Currencies.CountAsync();

            var list = await this.context.Currencies.OrderBy(o => o.Order)
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

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<int> Update(List<CurrencyIn> input)
        {
            var myList = await this.context.Currencies.ToListAsync();
            var myCounter = myList.Count + 1;

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

                this.context.SeedAddOrUpdate(p => p.Currency, p => new { p.ReasonToOneEuro, p.ChangeAt }, currencyEntity);

                myCounter = myCounter + 1;
            }

            return await this.context.SaveChangesAsync();
        }
    }
}