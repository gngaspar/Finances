// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMock.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The Mock interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.NUnit.Tests.Mocks
{
    /// <summary>
    /// The Mock interface.
    /// </summary>
    /// <typeparam name="T">
    /// The Type.
    /// </typeparam>
    public interface IMock<T> where T : class
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        object Create();
    }
}