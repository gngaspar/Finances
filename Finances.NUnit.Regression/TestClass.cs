// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestClass.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   Defines the TestClass type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.NUnit.Regression
{
    using Finances.NUnit.Regression.Selenium;

    using global::NUnit.Framework;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    /// <summary>
    /// The test class.
    /// </summary>
    [TestFixture]
    public class TestClass
    {
        /// <summary>
        /// The test method.
        /// </summary>
        [Test]
        public void TestMethod()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl( "http://localhost:3001/index.html" );
            var element = driver.GetHtmlElement( "index", "txtBank" );

            // var element = driver.FindElement(By.Id("bankInput"));
            element.SendKeys( "mon" );

            var search = driver.GetHtmlElement( "index", "bntSearch" );
            search.Click();

            driver?.Quit();
        }
    }
}