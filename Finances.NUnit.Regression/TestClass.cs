namespace Finances.NUnit.Regression
{
    using global::NUnit.Framework;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    using Finances.NUnit.Regression.Selenium;

    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestMethod()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:3001/index.html");
            var element = driver.GetHtmlElement("index", "txtBank");
            // var element = driver.FindElement(By.Id("bankInput"));
            element.SendKeys("mon");

            var search = driver.GetHtmlElement("index", "bntSearch");
            search.Click();


            driver?.Quit();
        }
    }
}
