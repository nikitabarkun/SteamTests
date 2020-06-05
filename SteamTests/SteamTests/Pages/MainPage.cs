using OpenQA.Selenium;
using TestFramework;
using TestFramework.Elements;
using TestFramework.PageObject;

namespace SteamTests.Pages
{
    public class MainPage : PageObject
    {
        private const string downloadButtonSelector = "//div[contains(@class, 'header_installsteam_btn_green')]";
        private const string dropDownElementsSelector = "//div[@id='genre_flyout']//a[@class='popup_menu_item']";
        private const string dropDownSelector = "//div[@class='store_nav']//div[@id='genre_tab']";

        public Button DownloadButton;
        public DropDownMenu CategoriesMenu;

        public MainPage() : base()
        {
            Open(SingleWebDriver.Configuration.SiteName);

            DownloadButton = new Button(By.XPath(downloadButtonSelector), "Download button");
            CategoriesMenu = new DropDownMenu(By.XPath(dropDownElementsSelector), By.XPath(dropDownSelector), "Categories menu");

            Logger.GetInstance().LogLine($"Created main page.");
        }

        public void SelectCategory(string category)
        {
            CategoriesMenu.Hover();
            CategoriesMenu.ClickElementByInnerText(category);
        }
    }
}
