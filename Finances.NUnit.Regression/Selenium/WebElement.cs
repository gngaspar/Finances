namespace Finances.NUnit.Regression.Selenium
{
    using Finances.NUnit.Regression.Common;

    using OpenQA.Selenium;

    /// <summary>
    /// The web element helper.
    /// </summary>
    public static class WebElementHelper
    {
        /// <summary>
        /// The get html element.
        /// </summary>
        /// <param name="driver">
        /// The driver.
        /// </param>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <param name="elementName">
        /// The element name.
        /// </param>
        /// <returns>
        /// The <see cref="IWebElement"/>.
        /// </returns>
        /// <exception cref="NotFoundException">
        /// The NotFoundException.
        /// </exception>
        public static IWebElement GetHtmlElement(this IWebDriver driver, string page, string elementName)
        {
            ////TODO: use linq, but i need the collections to implement the IList

            foreach (PageConfigElement pageElement in PagesSection.Instance.Selectors)
            {
                if (pageElement.Name.ToLowerInvariant() != page.ToLowerInvariant())
                {
                    continue;
                }

                foreach (SelectorConfigElement selector in pageElement.Selectors)
                {
                    if (selector.Name.ToLowerInvariant() == elementName.ToLowerInvariant())
                    {
                        if (selector.Type == "Id")
                        {
                            return driver.FindElement(By.Id(selector.Selector));
                        }
                        if (selector.Type == "Name")
                        {
                            return driver.FindElement(By.Name(selector.Selector));
                        }

                        throw new NotFoundException("Type " + selector.Type + " was not found in WebElementHelper.");
                    }
                }
                    
                throw new NotFoundException("Element " + elementName + " was not found in the configuration of Page " + page + " check App.Config.");
            }

            throw new NotFoundException("Page " + page + " was not found in the configuration check App.Config.");
        }
    }
}
