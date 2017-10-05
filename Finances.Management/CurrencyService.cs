// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrencyService.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The currency service implementation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Management
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Finances.Contract;
    using Finances.Contract.Banking;
    using Finances.Domain;
    using Finances.Domain.Repository;

    /// <summary>
    /// The currency service implementation.
    /// </summary>
    public class CurrencyService : ICurrencyService
    {
        /// <summary>
        /// The currency repository
        /// </summary>
        private readonly ICurrencyRepository currencyRepository;

        /// <summary>
        /// The cache provider.
        /// </summary>
        private ICacheProvider cacheProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyService"/> class.
        /// </summary>
        /// <param name="currencyRepository">
        /// The currency repository.
        /// </param>
        /// <param name="cacheProvider">
        /// The cache Provider.
        /// </param>
        public CurrencyService( ICurrencyRepository currencyRepository, ICacheProvider cacheProvider )
        {
            this.currencyRepository = currencyRepository;
            this.cacheProvider = cacheProvider;
        }

        /// <summary>
        /// Converts the specified amount.
        /// </summary>
        /// <param name="convert">
        /// The convert.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// The argument null exception.
        /// </exception>
        /// <exception cref="Exception">
        /// The exception.
        /// </exception>
        public async Task<decimal> Convert( ConvertRequest convert )
        {
            if ( convert == null )
            {
                throw new ArgumentNullException( nameof( convert ) );
            }

            if ( string.IsNullOrEmpty( convert.FromCurrency ) || string.IsNullOrEmpty( convert.FromCurrency.Trim() ) )
            {
                throw new Exception( "From currency cant be empty." );
            }

            ValidateCurrency( convert.FromCurrency );

            if ( string.IsNullOrEmpty( convert.ToCurrency ) || string.IsNullOrEmpty( convert.ToCurrency.Trim() ) )
            {
                throw new Exception( "To currency cant be empty." );
            }

            ValidateCurrency( convert.ToCurrency );

            if ( string.Equals( convert.FromCurrency, convert.ToCurrency, StringComparison.CurrentCultureIgnoreCase ) )
            {
                throw new Exception( "Cant convert to the same currency." );
            }

            if ( convert.Amount == 0 )
            {
                throw new Exception( "Amount must be different of Zero (0)." );
            }

            var listOfCurrencies = this.cacheProvider.Currencies;

            if ( listOfCurrencies == null )
            {
                throw new Exception( "Cant get currencies." );
            }

            var from = listOfCurrencies.FirstOrDefault( i => i.Code == convert.FromCurrency.ToUpper() );
            if ( from == null )
            {
                throw new Exception( $"Cant find { convert.FromCurrency} currency." );
            }

            var to = listOfCurrencies.FirstOrDefault( i => i.Code == convert.ToCurrency.ToUpper() );
            if ( to == null )
            {
                throw new Exception( $"Cant find { convert.ToCurrency} currency." );
            }

            if ( from.ReasonToOneEuro == 0 && to.ReasonToOneEuro == 0 )
            {
                return convert.Amount;
            }

            if ( to.ReasonToOneEuro == 0 )
            {
                return convert.Amount / from.ReasonToOneEuro;
            }

            if ( from.ReasonToOneEuro == 0 )
            {
                return convert.Amount * to.ReasonToOneEuro;
            }

            return to.ReasonToOneEuro * ( convert.Amount / from.ReasonToOneEuro );
        }

        /// <summary>
        /// The list.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<CurrencyListResponse> List()
        {
            return await this.currencyRepository.List();
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
        /// <exception cref="ArgumentNullException">
        /// The exception.
        /// </exception>
        public async Task<int> Update( List<CurrencyIn> input )
        {
            if ( input == null )
            {
                throw new ArgumentNullException( nameof( input ) );
            }

            var date = await this.currencyRepository.GetTheHistoryLastDay();
            if ( date.Date != DateTime.Now.AddDays( -1 ).Date )
            {
                await this.currencyRepository.CopyToHistory();
            }

            foreach ( var currencyIn in input )
            {
                this.ValidateCurrency( currencyIn );
            }

            var output = await this.currencyRepository.Update( input );
            this.cacheProvider.Currencies = null;

            return output;

        }

        /// <summary>
        /// The history.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<HistoryListResponse> GetHistory( HistoryListRequest request )
        {
            var numberOfdays = ( request.EndDate - request.StartDate ).TotalDays;
            if ( numberOfdays >= 370 )
            {
                throw new Exception( "Only 365 days available." );
            }

            var numberOfCurrencies = request.Currencies.Count( i => i != Constants.Eur );
            if ( numberOfCurrencies > 3 )
            {
                throw new Exception( "Only 3 Currencies available." );
            }

            var historyListResponse = new HistoryListResponse();
            var listOf = new List<HistoryOut>();
            foreach ( var currency in request.Currencies.Where( v => v != Constants.Eur ) )
            {
                ValidateCurrency( currency );
                var temp = await this.currencyRepository.GetCurrency( currency );
                if ( temp == null )
                {
                    throw new Exception( $"Couldnt find currency {currency} ." );
                }

                var list = await this.currencyRepository.GetHistory( currency, request.StartDate, request.EndDate );

                var newItem = new HistoryOut
                {
                    Code = temp.Code,
                    Name = temp.Name,
                    ReasonToOneEuro = temp.ReasonToOneEuro,
                    ChangeAt = temp.ChangeAt,
                    Data = list
                };

                listOf.Add( newItem );
            }

            historyListResponse.Data = listOf;
            historyListResponse.NumberOfItems = listOf.Count;

            return historyListResponse;
        }

        /// <summary>
        /// The validate currency.
        /// </summary>
        /// <param name="currencyIn">
        /// The currency in.
        /// </param>
        /// <exception cref="Exception">
        /// The Exception.
        /// </exception>
        private static void ValidateCurrency( string currencyIn )
        {
            if ( string.IsNullOrEmpty( currencyIn ) || string.IsNullOrEmpty( currencyIn.Trim() ) )
            {
                throw new Exception( "The currency code cant be empty." );
            }

            if ( currencyIn.Length != 3 )
            {
                throw new Exception( $"The currency code {currencyIn} must be 3 chars." );
            }
        }

        /// <summary>
        /// The validate currency.
        /// </summary>
        /// <param name="currencyIn">
        /// The currency in.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// The argument null exception.
        /// </exception>
        /// <exception cref="Exception">
        /// The exception.
        /// </exception>
        private void ValidateCurrency( CurrencyIn currencyIn )
        {
            if ( currencyIn == null )
            {
                throw new ArgumentNullException( nameof( currencyIn ) );
            }

            ValidateCurrency( currencyIn.Code );

            if ( currencyIn.ReasonToOneEuro < 0 )
            {
                throw new Exception( $"In the currency code { currencyIn.Code}, ReasonToOneEuro cant be smaller than zero." );
            }
        }
    }
}