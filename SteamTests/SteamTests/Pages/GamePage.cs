using OpenQA.Selenium;
using SteamTests.HelpClasses;
using TestFramework;
using TestFramework.Elements;
using TestFramework.PageObject;

namespace SteamTests.Pages
{
    public class GamePage : PageObject
    {
        private const string pricesPanelSelector = "//div[@class='discount_block game_purchase_discount']";
        private const string discountsSelector = "//div[@class='discount_pct']";
        private const string oldPricesSelector = "//div[@class='discount_original_price']";
        private const string newPricesSelector = "//div[@class='discount_final_price']";
        private const string innerText = "innerText";

        public Label Discount;
        public Label OldPrice;
        public Label NewPrice;

        public GamePage() : base()
        {
            Discount = new Label(By.XPath($"{pricesPanelSelector}{discountsSelector}"), "Discount label");
            OldPrice = new Label(By.XPath($"{pricesPanelSelector}{oldPricesSelector}"), "Old price label");
            NewPrice = new Label(By.XPath($"{pricesPanelSelector}{newPricesSelector}"), "New price label");

            Logger.GetInstance().LogLine($"Created game page.");
        }

        public DiscountInfo GetDiscountInfo()
        {
            string discount = Discount.GetAttribute(innerText);
            string oldPrice = OldPrice.GetAttribute(innerText);
            string newPrice = NewPrice.GetAttribute(innerText);

            return new DiscountInfo(discount, oldPrice, newPrice);
        }
    }
}
