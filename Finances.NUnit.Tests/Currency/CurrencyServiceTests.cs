namespace Finances.NUnit.Tests.Currency
{
    using System;
    using System.Threading.Tasks;

    using Finances.Contract.Banking;
    using Finances.Domain.Repository;
    using Finances.Management;

    using global::NUnit.Framework;

    [TestFixture]
    public class CurrencyServiceTests : BaseTest
    {
        [SetUp]
        public void TestInitialize()
        {
        }

        [TearDown]
        public void TestCleanup()
        {
        }

        [Test]
        public void ConvertShouldReturnConvertedValue()
        {
            var service = this.GetCurrencyService();
            var input = new ConvertRequest { Amount = 10, FromCurrency = "EUR", ToCurrency = "PLN" };

            var result = service.Convert(input);
            Assert.NotNull(result);
            Assert.NotNull(result.Result);
            Assert.IsTrue(result.Status == TaskStatus.RanToCompletion);
            Assert.AreEqual(result.Result, 42m);
        }

        [Test]
        public void ConvertToTheSameCurrency()
        {
            var service = this.GetCurrencyService();
            var input = new ConvertRequest { Amount = 10, FromCurrency = "EUR", ToCurrency = "EUR" };
            var result = service.Convert(input);
            Assert.IsTrue(result.Status == TaskStatus.Faulted);
            Assert.IsTrue(result.Exception != null);
        }
    }
}