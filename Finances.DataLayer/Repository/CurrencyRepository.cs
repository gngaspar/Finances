// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrencyRepository.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The currency repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

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
        /// <param name="bankingDbContext">
        /// The banking database context.
        /// </param>
        public CurrencyRepository( BankingDbContext bankingDbContext )
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
            var queryResult = await this.context.Currencies.Where( i => i.ReasonToOneEuro != 0 ).Select( c => new
            {
                c.ReasonToOneEuro,
                c.Currency
            } ).ToListAsync();

            this.context.CurrencyHistory.AddRange( queryResult.Select( c => new CurrencyHistoryEntity
            {
                ReasonToOneEuro = c.ReasonToOneEuro,
                Currency = c.Currency,
                CreatedAtDay = DateTime.Now.AddDays( -1 )
            } ) );

            return await this.context.SaveChangesAsync();
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

            if ( !hasAny )
            {
                return DateTime.Now.AddYears( -1 );
            }

            return await this.context.CurrencyHistory.MaxAsync( i => i.CreatedAtDay );
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

            var list = await this.context.Currencies.OrderBy( o => o.Order )
                        .Select( currency => new CurrencyOut
                        {
                            Name = currency.Name,
                            Code = currency.Currency,
                            ReasonToOneEuro = currency.ReasonToOneEuro,
                            ChangeAt = currency.ChangeAt,
                        } ).ToListAsync();

            var result = new CurrencyListResponse
            {
                NumberOfItems = queryResult,
                Data = list
            };

            return result;
        }

        public List<CurrencyOut> All()
        {
            return this.context.Currencies.OrderBy( o => o.Order )
                .Select( currency => new CurrencyOut
                {
                    Name = currency.Name,
                    Code = currency.Currency,
                    ReasonToOneEuro = currency.ReasonToOneEuro,
                    ChangeAt = currency.ChangeAt,
                } ).ToList();
        }

        /// <summary>
        /// The get currency.
        /// </summary>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<CurrencyOut> GetCurrency( string code )
        {
            var cur = await this.context.Currencies.Where( i => i.Currency == code ).FirstOrDefaultAsync();
            if ( cur != null )
            {
                return new CurrencyOut
                {
                    Code = cur.Currency,
                    Name = cur.Name,
                    ReasonToOneEuro = cur.ReasonToOneEuro,
                    ChangeAt = cur.ChangeAt
                };
            }

            return null;
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
        public async Task<int> Update( List<CurrencyIn> input )
        {
            var currencyEntities = await this.context.Currencies.ToListAsync();
            var counter = currencyEntities.Count + 1;

            foreach ( var currency in input.OrderBy( i => i.Code ) )
            {
                currency.Code = currency.Code.ToUpper();

                var currencyEntity = new CurrencyEntity
                {
                    Currency = currency.Code,
                    ReasonToOneEuro = currency.ReasonToOneEuro
                };

                var oldCurreny = currencyEntities.FirstOrDefault( i => i.Currency == currency.Code );

                currencyEntity.Order = oldCurreny?.Order ?? ( currencyEntity.Order = counter );
                currencyEntity.Name = oldCurreny != null ? oldCurreny.Name : currency.Code;
                currencyEntity.ChangeAt = DateTime.Now;

                this.context.SeedAddOrUpdate( p => p.Currency, p => new { p.ReasonToOneEuro, p.ChangeAt }, currencyEntity );

                counter = counter + 1;
            }

            return await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// The get history.
        /// </summary>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <param name="startDay">
        /// The start day.
        /// </param>
        /// <param name="endDay">
        /// The end day.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<List<HistoryValue>> GetHistory( string code, DateTime startDay, DateTime endDay )
        {
            return await this.context.CurrencyHistory.Where( i => i.Currency == code && i.CreatedAtDay >= startDay && i.CreatedAtDay <= endDay )
                .OrderBy( i => i.CreatedAtDay )
                .Select( histo => new HistoryValue { ChangeAt = histo.CreatedAtDay, ReasonToOneEuro = histo.ReasonToOneEuro } ).ToListAsync();
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}