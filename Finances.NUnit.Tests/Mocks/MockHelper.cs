namespace Finances.NUnit.Tests.Mocks
{
    /// <summary>
    /// The mock helper.
    /// </summary>
    public class MockHelper
    {
        /// <summary>
        /// The mock service proxy.
        /// </summary>
        /// <returns>
        /// The <see cref="ServiceProxyMock"/>.
        /// </returns>
        public static ServiceProxyMock MockServiceProxy()
        {
            return new ServiceProxyMock();
        }
    }
}