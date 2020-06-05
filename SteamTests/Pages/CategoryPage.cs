using System.Collections.Generic;
using TestFramework;
using TestFramework.Elements;
using TestFramework.PageObject;
using SteamTests.HelpElements;
using OpenQA.Selenium;

namespace SteamTests.Pages
{
    public class CategoryPage : PageObject
    {
        public string Name;

        private const string topSellersButtonSelector = "//div[@class='store_horizontal_minislider_ctn']//div[@id='tab_select_TopSellers']";
        private const string discountedGamesSelector = "//*[@id='TopSellersRows']//a[contains(@class, 'app_impression_tracked')]//div[@class='discount_block tab_item_discount']";
        private const string discountedGamesNamesSelector = "//parent::a[contains(@class, 'app_impression_tracked')]//div[contains(@class, 'tab_item_name')]";
        
        public Button TopSellersButton;
        public List<SteamGame> DiscountedGames;

        public CategoryPage(string name) : base()
        {
            this.Name = name;

            TopSellersButton = new Button(By.XPath(topSellersButtonSelector), "Top-sellers button");
            DiscountedGames = SteamGame.GetDiscountedGames(discountedGamesSelector, discountedGamesNamesSelector);

            Logger.GetInstance().LogLine($"Created {Name} category page.");
        }

        public SteamGame SelectGameWithHighestDiscount()
        {
            double maxDiscount = 0;
            int gameIndex = 0;

            for (int i = 0; i < DiscountedGames.Count; i++)
            {
                if (DiscountedGames[i].DiscountInfo.Discount > maxDiscount)
                {
                    maxDiscount = DiscountedGames[i].DiscountInfo.Discount;
                    gameIndex = i;
                }
            }

            DiscountedGames[gameIndex].Click();
            return DiscountedGames[gameIndex];
        }

        public SteamGame SelectGameWithLowestDiscount()
        {
            double minDiscount = 100;
            int gameIndex = 0;

            for (int i = 0; i < DiscountedGames.Count; i++)
            {
                if (DiscountedGames[i].DiscountInfo.Discount < minDiscount)
                {
                    minDiscount = DiscountedGames[i].DiscountInfo.Discount;
                    gameIndex = i;
                }
            }

            DiscountedGames[gameIndex].Click();
            return DiscountedGames[gameIndex];
        }
    }
}
