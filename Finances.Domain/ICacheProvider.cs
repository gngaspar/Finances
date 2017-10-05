// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICacheProvider.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The CacheProvider interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Domain
{
    using System;

    /// <summary>
    /// The CacheProvider interface.
    /// </summary>
    public interface ICacheProvider
    {
        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="key">The key input.</param>
        /// <returns>Service return.</returns>
        T GetObject<T>( string key );

        /// <summary>
        /// Sets the object.
        /// </summary>
        /// <param name="value">The value input.</param>
        /// <param name="key">The key input.</param>
        /// <param name="slidingExpiration">The sliding expiration.</param>
        /// <param name="absoluteExpiration">The absolute expiration.</param>
        void SetObject( object value, string key, TimeSpan? slidingExpiration, TimeSpan? absoluteExpiration );
    }
}
