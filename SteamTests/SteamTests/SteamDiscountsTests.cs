using NUnit.Framework;
using TestFramework;
using SteamTests.Pages;
using SteamTests.HelpClasses;
using SteamTests.HelpElements;

namespace SteamTests
{
    [TestFixture]
    class SteamDiscountsTests : SteamBaseTest
    { 
        [SetUp]
        public new void Setup()
        {
            base.Setup();
        }

        [Test]
        public void HighestDiscountCalculationCheck()
        {
            Logger.GetInstance().LogLine($"STEP: Opening main page...");
            MainPage mainPage = new MainPage();

            mainPage.SelectCategory(FileUtils.GetLocalizedString("Action"));
            Logger.GetInstance().LogLine($"STEP: Selected 'action' category.");

            CategoryPage gameCategoryPage = new CategoryPage(FileUtils.GetLocalizedString("Action"));
            gameCategoryPage.TopSellersButton.Click();
            SingleWebDriver.ScrollTo(0, 800);
            SteamGame gameWithHighestDiscount = gameCategoryPage.SelectGameWithHighestDiscount();
            Logger.GetInstance().LogLine($"STEP: Game with highest discount is got.");

            GamePage gamePage = new GamePage();
            DiscountInfo discountInfoFromGamePage = gamePage.GetDiscountInfo();
            Assert.Multiple(() =>
            {
                Assert.AreEqual(gameWithHighestDiscount.DiscountInfo.Discount, discountInfoFromGamePage.Discount,
                    $"Discount from category page {gameWithHighestDiscount.DiscountInfo.Discount} is not equal to discount from game page.");
                Assert.AreEqual(gameWithHighestDiscount.DiscountInfo.OldPrice, discountInfoFromGamePage.OldPrice,
                    $"Old price from category page {gameWithHighestDiscount.DiscountInfo.OldPrice} is not equal to old price from game page.");
                Assert.AreEqual(gameWithHighestDiscount.DiscountInfo.NewPrice, discountInfoFromGamePage.NewPrice,
                    $"New price from category page {gameWithHighestDiscount.DiscountInfo.NewPrice} is not equal to new price from game page.");

            });
            Logger.GetInstance().LogLine($"STEP: Test complete.");
        }

        [Test]
        public void LowestDiscountCalculationCheck()
        {
            Logger.GetInstance().LogLine($"STEP: Opening main page...");
            MainPage mainPage = new MainPage();

            mainPage.SelectCategory(FileUtils.GetLocalizedString("Indie"));
            Logger.GetInstance().LogLine($"STEP: Selected 'indie' category.");

            CategoryPage gameCategoryPage = new CategoryPage(FileUtils.GetLocalizedString("Indie"));
            gameCategoryPage.TopSellersButton.Click();
            SingleWebDriver.ScrollTo(0, 1000);
            SteamGame gameWithLowestDiscount = gameCategoryPage.SelectGameWithLowestDiscount();
            Logger.GetInstance().LogLine($"STEP: Game with lowest discount is got.");

            GamePage gamePage = new GamePage();
            DiscountInfo discountInfoFromGamePage = gamePage.GetDiscountInfo();
            Assert.Multiple(() =>
            {
                Assert.AreEqual(gameWithLowestDiscount.DiscountInfo.Discount, discountInfoFromGamePage.Discount,
                    $"Discount from category page {gameWithLowestDiscount.DiscountInfo.Discount} is not equal to discount from game page.");
                Assert.AreEqual(gameWithLowestDiscount.DiscountInfo.OldPrice, discountInfoFromGamePage.OldPrice,
                    $"Old price from category page {gameWithLowestDiscount.DiscountInfo.OldPrice} is not equal to old price from game page.");
                Assert.AreEqual(gameWithLowestDiscount.DiscountInfo.NewPrice, discountInfoFromGamePage.NewPrice,
                    $"New price from category page {gameWithLowestDiscount.DiscountInfo.NewPrice} is not equal to new price from game page.");

            });
            Logger.GetInstance().LogLine($"STEP: Test complete.");
        }

        [OneTimeTearDown]
        public new void TearDown()
        {
            base.TearDown();
        }
    }
}
