using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TestFramework.Elements
{
    public abstract class BaseElement
    {
        public string Name;

        protected IWebDriver driver;

        protected By locator;

        public BaseElement(By locator, string name)
        {
            this.Name = name;
            this.driver = SingleWebDriver.GetInstance();
            this.locator = locator;
            Logger.GetInstance().LogLine($"Created '{Name}' element.");
        }

        public void Click()
        {
            if (IsEnabled())
            {
                driver.FindElement(locator).Click();
                Logger.GetInstance().LogLine($"Click on element '{Name}'.");
            }
            else throw new WebDriverException($"ERROR: Can't click on {Name} element.");
        }

        public void Hover()
        {
            if (IsEnabled())
            {
                Actions action = new Actions(driver);
                action.MoveToElement(driver.FindElement(locator)).Perform();
                Logger.GetInstance().LogLine($"Hover on element '{Name}'.");
            }
            else throw new WebDriverException($"ERROR: Can't hover on {Name} element.");
        }

        public string GetAttribute(string attribute)
        {
            if (IsEnabled())
            {
                Logger.GetInstance().LogLine($"Getting '{attribute}' attribute of '{Name}'...");
                return driver.FindElement(locator).GetAttribute(attribute);
            }
            Logger.GetInstance().LogLine($"ERROR: Can't find element '{Name}' to get attribute.");
            throw new WebDriverException($"Can't find element '{Name}' to get attribute.");
        }

        protected bool IsEnabled()
        {
            try
            {
                Logger.GetInstance().LogLine($"Checking if '{Name}' element is enabled.");
                bool result = (driver.FindElement(locator).Enabled ? true : false);
                return result;
            }
            catch (StaleElementReferenceException)
            {
                Logger.GetInstance().LogLine($"ERROR: '{Name}' element is not enabled.");
                return false;
            }
        }
    }
}
