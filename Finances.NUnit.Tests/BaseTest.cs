namespace Finances.NUnit.Tests
{
    using Finances.Domain;
    using Finances.Domain.Repository;
    using Finances.Endpoint.WebApi.ApiControllers;
    using Finances.Management;
    using Finances.NUnit.Tests.Mocks;
    using Finances.NUnit.Tests.Mocks.Controller;

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
        public ServiceProxyMock ServiceProxy => this.serviceProxy ?? (this.serviceProxy = MockHelper.MockServiceProxy());


        public ICurrencyService GetCurrencyService()
        {
            return new CurrencyService(this.ServiceProxy.GetMock<ICurrencyRepository>().Object);
        }

        public CurrencyController GetCurrencyController()
        {
            return new CurrencyController(this.GetCurrencyService());
        }
    }
}