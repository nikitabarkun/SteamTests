using OpenQA.Selenium;

namespace TestFramework.PageObject
{
    public abstract class PageObject
    {
        protected IWebDriver driver;

        public PageObject()
        {
            this.driver = SingleWebDriver.GetInstance();
        }

        public void Open(string url)
        {
            driver.Navigate().GoToUrl(url);
            Logger.GetInstance().LogLine($"Opening page by URL:{url}.");
        }
    }
}
