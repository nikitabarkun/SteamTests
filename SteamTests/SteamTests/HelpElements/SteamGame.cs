using OpenQA.Selenium;
using SteamTests.HelpClasses;
using System.Collections.Generic;
using System.Linq;
using TestFramework;
using TestFramework.Elements;

namespace SteamTests.HelpElements
{
    public class SteamGame : Button
    {
        public DiscountInfo DiscountInfo;

        private const string discountsSelector = "//div[@class='discount_pct']";
        private const string oldPricesSelector = "//div[@class='discount_original_price']";
        private const string newPricesSelector = "//div[@class='discount_final_price']";
        private const string innerText = "innerText";

        public SteamGame(string discount, string oldPrice, string newPrice, By locator, string name) : base(locator, name)
        {
            DiscountInfo = new DiscountInfo(discount, oldPrice, newPrice);
        }

        public static List<SteamGame> GetDiscountedGames(string selector, string namesSelector)
        {
            IWebDriver driver = SingleWebDriver.GetInstance();

            IReadOnlyCollection<IWebElement> gotButtons = driver.FindElements(By.XPath(selector));
            IReadOnlyCollection<IWebElement> gotNames = driver.FindElements(By.XPath($"{selector}{namesSelector}"));
            IReadOnlyCollection<IWebElement> gotDiscounts = driver.FindElements(By.XPath($"{selector}{discountsSelector}"));
            IReadOnlyCollection<IWebElement> gotOldPrices = driver.FindElements(By.XPath($"{selector}{oldPricesSelector}"));
            IReadOnlyCollection<IWebElement> gotNewPrices = driver.FindElements(By.XPath($"{selector}{newPricesSelector}"));

            List<SteamGame> steamGames = new List<SteamGame>();
            int i = 0;

            foreach (IWebElement element in gotButtons)
            {
                string discount = gotDiscounts.ElementAt(i).GetAttribute(innerText);
                string oldPrice = gotOldPrices.ElementAt(i).GetAttribute(innerText);
                string newPrice = gotNewPrices.ElementAt(i).GetAttribute(innerText);
                string name = gotNames.ElementAt(i).GetAttribute(innerText);
                string uniqueSelector = $"{selector}/..//*[text()=\"{name}\"]";

                steamGames.Add(new SteamGame(discount, oldPrice, newPrice, By.XPath(uniqueSelector), name));
                i++;
            }
            return steamGames;
        }
    }
}
