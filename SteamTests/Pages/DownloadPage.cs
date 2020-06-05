using OpenQA.Selenium;
using TestFramework;
using TestFramework.Elements;
using TestFramework.PageObject;

namespace SteamTests.Pages
{
    public class DownloadPage : PageObject
    {
        private const string downloadButtonSelector = "//div[@id='about_header']//div[@class='about_install win ']";

        public Button DownloadButton;

        public DownloadPage() : base()
        {
            DownloadButton = new Button(By.XPath(downloadButtonSelector), "Download button");

            Logger.GetInstance().LogLine($"Created download page.");
        }
    }
}
