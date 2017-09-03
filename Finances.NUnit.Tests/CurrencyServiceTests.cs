namespace Finances.NUnit.Tests
{
    using Finances.Domain.Repository;
    using Finances.Management;

    using global::NUnit.Framework;

    using Moq;

    [TestFixture]
    public class CurrencyServiceTests
    {
        private MockRepository mockRepository;

        private Mock<ICurrencyRepository> mockCurrencyRepository;

        [SetUp]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockCurrencyRepository = this.mockRepository.Create<ICurrencyRepository>();
        }

        [TearDown]
        public void TestCleanup()
        {
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void TestMethod1()
        {
            CurrencyService service = this.CreateService();
        }

        private CurrencyService CreateService()
        {
            return new CurrencyService(
                this.mockCurrencyRepository.Object);
        }
    }
}