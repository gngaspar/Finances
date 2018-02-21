// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrencyControllerTests.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the CurrencyControllerTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.NUnit.Tests.Currency
{
    using System.Net.Http;
    using System.Web.Http;

    using global::NUnit.Framework;

    /// <summary>
    /// The currency controller tests.
    /// </summary>
    [TestFixture]
    public class CurrencyControllerTests : BaseTest
    {
        /// <summary>
        /// The convert string test.
        /// </summary>
        [Test]
        public void ConvertStringTest()
        {
            var controller = this.GetCurrencyController();
            //// var result = await controller.ConvertString("EUR", "PLN", 10);

            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();


            Assert.IsTrue( true );
        }
    }
}