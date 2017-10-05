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
    using System.Runtime.Caching;

    using Finances.Domain;

    /// <summary>
    /// The cache provider.
    /// </summary>
    public class CacheProvider : ICacheProvider
    {
        ///// <summary>
        ///// The locker.
        ///// </summary>
        /////private static readonly object Locker = new object();

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
        /// <param name="slidingExpiration">
        /// The sliding expiration.
        /// </param>
        /// <param name="absoluteExpiration">
        /// The absolute expiration.
        /// </param>
        public void SetObject( object value, string key, TimeSpan? slidingExpiration, TimeSpan? absoluteExpiration )
        {
            if ( value == null )
            {
                return;
            }

            ObjectCache cache = MemoryCache.Default;

            CacheItemPolicy policy = new CacheItemPolicy();
            if ( slidingExpiration.HasValue )
            {
                policy.SlidingExpiration = slidingExpiration.Value; ////TODO
            }
            else if ( absoluteExpiration.HasValue )
            {
                policy.AbsoluteExpiration = DateTimeOffset.Now.Add( absoluteExpiration.Value );
            }
            else
            {
                ////throw new InvalidAttributeException( "Expiration time is required" ); TODO
            }

            cache.AddOrGetExisting( key, value, policy );
        }
    }
}