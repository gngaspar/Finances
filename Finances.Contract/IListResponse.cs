// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IResponse.cs" company="GNG">
// The Response interface.
// </copyright>
// <summary>
// The Response interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract
{
    using System.Collections.Generic;

    /// <summary>
    /// The Response interface.
    /// </summary>
    /// <typeparam name="T">
    /// The Type
    /// </typeparam>
    public interface IListResponse<T>
    {
        /// <summary>
        /// Gets or sets the number of found items.
        /// </summary>
        int NumberOfItems { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        T[] Data { get; set; }
    }
}