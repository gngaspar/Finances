namespace Finances.NUnit.Tests.Currency
{
    using global::NUnit.Framework;

    [TestFixture()]
    public class CurrencyControllerTests : BaseTest
    {
        [Test()]
        public void ConvertStringTest()
        {
            var controller = this.GetCurrencyController();
            //var result = await controller.ConvertString("EUR", "PLN", 10);
        }
    }
}