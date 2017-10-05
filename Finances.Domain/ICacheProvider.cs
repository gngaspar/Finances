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
    using System.Collections.Generic;

    using Finances.Contract.Banking;

    /// <summary>
    /// The CacheProvider interface.
    /// </summary>
    public interface ICacheProvider
    {
        /// <summary>
        /// Gets the currencies.
        /// </summary>
        List<CurrencyOut> Currencies { get; }

        /// <summary>
        /// Gets the banks.
        /// </summary>
        List<BankOut> Banks { get; }

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
        void SetObject( object value, string key );
    }
}
