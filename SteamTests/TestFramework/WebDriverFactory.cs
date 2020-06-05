using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace TestFramework
{
    public static class WebDriverFactory
    {
        public static IWebDriver InitiateBrowser(string browserName, string language)
        {
            switch (browserName)
            {
                case "chrome":
                    ChromeOptions options = new ChromeOptions();

                    options.AddArguments($"–lang = {language}");
                    options.AddArgument("--safebrowsing-disable-download-protection");
                    options.AddUserProfilePreference("safebrowsing", "enabled");
                    Logger.GetInstance().LogLine($"Creating chrome driver...");
                    return new ChromeDriver(options);

                case "firefox":
                    FirefoxProfile profile = new FirefoxProfile();

                    profile.SetPreference("intl.accept_languages", $"{language}");
                    profile.SetPreference("browser.download.manager.alertOnEXEOpen", false);
                    profile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/msword, application/csv, application/ris, text/csv, image/png, application/pdf, text/html, text/plain, application/zip, application/x-zip, application/x-zip-compressed, application/download, application/octet-stream");
                    profile.SetPreference("browser.download.manager.focusWhenStarting", false);
                    profile.SetPreference("browser.download.useDownloadDir", true);
                    profile.SetPreference("browser.helperApps.alwaysAsk.force", false);
                    profile.SetPreference("browser.download.manager.alertOnEXEOpen", false);
                    profile.SetPreference("browser.download.manager.closeWhenDone", true);
                    profile.SetPreference("browser.download.manager.showAlertOnComplete", false);
                    profile.SetPreference("browser.download.manager.useWindow", false);
                    profile.SetPreference("services.sync.prefs.sync.browser.download.manager.showWhenStarting", false);
                    profile.SetPreference("pdfjs.disabled", true);
                    Logger.GetInstance().LogLine($"Creating firefox driver...");
                    return new FirefoxDriver();

                default:
                    Logger.GetInstance().LogLine($"ERROR: Unknown browser name.");
                    throw new ArgumentException("Unknown browser name.");
            }
        }
    }
}