namespace Finances.NUnit.Tests
{
    using Finances.Domain.Repository;
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
        public ServiceProxyMock ServiceProxy => this.serviceProxy ?? (this.serviceProxy = MockHelper.MockServiceProxy());


        public CurrencyService GetCurrencyService()
        {
            return new CurrencyService(this.ServiceProxy.GetMock<ICurrencyRepository>().Object);
        }
    }
}