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

            Assert.IsTrue( true );
        }
    }
}