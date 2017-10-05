// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockHelper.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The mock helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.NUnit.Tests.Mocks
{
    using Finances.Endpoint.WebApi.Infrastructure;

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

        public static CacheProvider MockICacheProvider()
        {
            throw new System.NotImplementedException();
        }
    }
}