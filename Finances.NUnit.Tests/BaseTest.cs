// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseTest.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The base test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.NUnit.Tests
{
    using Finances.Domain;
    using Finances.Domain.Repository;
    using Finances.Endpoint.WebApi.ApiControllers;
    using Finances.Management;
    using Finances.NUnit.Tests.Mocks;

    /// <summary>
    /// The base test.
    /// </summary>
    public class BaseTest
    {
        /// <summary>
        /// The service proxy.
        /// </summary>
        private ServiceProxyMock serviceProxy;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseTest"/> class.
        /// </summary>
        public BaseTest()
        {
            this.serviceProxy = MockHelper.MockServiceProxy();
        }

        /// <summary>
        /// Gets the service proxy.
        /// </summary>
        public ServiceProxyMock ServiceProxy => this.serviceProxy ?? ( this.serviceProxy = MockHelper.MockServiceProxy() );

        /// <summary>
        /// The get currency service.
        /// </summary>
        /// <returns>
        /// The <see cref="ICurrencyService"/>.
        /// </returns>
        public ICurrencyService GetCurrencyService()
        {
            return new CurrencyService( this.ServiceProxy.GetMock<ICurrencyRepository>().Object );
        }

        /// <summary>
        /// The get currency controller.
        /// </summary>
        /// <returns>
        /// The <see cref="CurrencyController"/>.
        /// </returns>
        public CurrencyController GetCurrencyController()
        {
            return new CurrencyController( this.GetCurrencyService() );
        }
    }
}