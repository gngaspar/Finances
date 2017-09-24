namespace Finances.NUnit.Tests.Mocks
{
    /// <summary>
    /// The Mock interface.
    /// </summary>
    /// <typeparam name="T">
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