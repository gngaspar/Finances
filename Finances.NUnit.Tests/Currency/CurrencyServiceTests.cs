namespace Finances.NUnit.Tests.Currency
{
    using System;

    using Finances.Contract.Banking;
    using Finances.Domain.Repository;
    using Finances.Management;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Finances.Endpoint.WebApi;

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

            var output = new CurrencyListResponse();
            var list = new List<CurrencyOut>();
            var euro = new CurrencyOut
            {
                ChangeAt = DateTime.MinValue,
                Code = "EUR",
                Name = "Euro",
                ReasonToOneEuro = 0
            };
            var pln = new CurrencyOut
            {
                ChangeAt = DateTime.MinValue,
                Code = "PLN",
                Name = "Zlote",
                ReasonToOneEuro = 4.2m
            };
            list.Add(euro);
            list.Add(pln);
            output.Data = list;
            output.NumberOfItems = list.Count;


            this.mockCurrencyRepository = this.mockRepository.Create<ICurrencyRepository>();
            this.mockCurrencyRepository.Setup(x => x.List()).Returns(Task.FromResult(output));
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
            var input = new ConvertRequest { Amount = 10, FromCurrency = "EUR", ToCurrency = "PLN" };

            var result = service.Convert(input);
            Assert.NotNull(result);
        }

        private CurrencyService CreateService()
        {
            return new CurrencyService(
                this.mockCurrencyRepository.Object);
        }
    }
}