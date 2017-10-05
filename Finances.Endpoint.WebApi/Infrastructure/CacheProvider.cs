// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CacheProvider.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The cache provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Endpoint.WebApi.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Caching;

    using Finances.Contract.Banking;
    using Finances.Domain;
    using Finances.Domain.Repository;

    /// <summary>
    /// The cache provider.
    /// </summary>
    public class CacheProvider : ICacheProvider
    {
        /// <summary>
        /// The currency repository.
        /// </summary>
        private ICurrencyRepository currencyRepository;

        /// <summary>
        /// The bank repository.
        /// </summary>
        private IBankRepository bankRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheProvider"/> class. 
        /// The Cache Provider.
        /// </summary>
        /// <param name="currencyRepository">
        /// The currency Repository.
        /// </param>
        /// <param name="bankRepository">
        /// The bank Repository.
        /// </param>
        public CacheProvider( ICurrencyRepository currencyRepository, IBankRepository bankRepository )
        {
            this.currencyRepository = currencyRepository;
            this.bankRepository = bankRepository;
        }

        ///// <summary>
        ///// The locker.
        ///// </summary>
        /////private static readonly object Locker = new object();

        /// <summary>
        /// Gets the currencies.
        /// </summary>
        public List<CurrencyOut> Currencies
        {
            get
            {
                var list = this.GetObject<List<CurrencyOut>>( "Currencies" );

                if ( list == null || list.Count == 0 )
                {
                    list = new List<CurrencyOut>();
                    list.AddRange( this.currencyRepository.All() );
                    this.SetObject( list, "Currencies" );
                }

                return list;
            }
        }

        /// <summary>
        /// Gets the banks.
        /// </summary>
        public List<BankOut> Banks
        {
            get
            {
                var list = this.GetObject<List<BankOut>>( "Banks" );

                if ( list == null || list.Count == 0 )
                {
                    list = new List<BankOut>();
                    list.AddRange( this.bankRepository.All() );
                    this.SetObject( list, "Banks" );
                }

                return list;
            }
        }

        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="key">The key input.</param>
        /// <returns>Service return.</returns>
        public T GetObject<T>( string key )
        {
            ObjectCache cache = MemoryCache.Default;

            var value = cache[ key ];
            if ( value == null )
            {
                return default( T );
            }

            return (T) value;
        }

        /// <summary>
        /// Sets the object.
        /// </summary>
        /// <param name="value">
        /// The value input.
        /// </param>
        /// <param name="key">
        /// The key input.
        /// </param>
        public void SetObject( object value, string key )
        {
            if ( value == null )
            {
                return;
            }

            ObjectCache cache = MemoryCache.Default;

            CacheItemPolicy policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddDays( 1 ) };
            cache.AddOrGetExisting( key, value, policy );
        }
    }
}