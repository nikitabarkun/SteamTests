using OpenQA.Selenium;
using System;
using System.IO;

namespace TestFramework
{
    public class SingleWebDriver
    {
        public static TestConfiguration Configuration;

        private static IWebDriver instance;

        public static IWebDriver GetInstance()
        {
            if (instance == null)
            {
                string configurationPath = $"{Path.GetFullPath("..\\..\\..\\")}/config.json";

                Configuration = new TestConfiguration(configurationPath);

                instance = WebDriverFactory.InitiateBrowser(Configuration.BrowserName, Configuration.Language);
                instance.Manage().Window.Maximize();
                instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                Logger.GetInstance().LogLine($"Driver instance created.");
            }
            return instance;
        } 

        public static void ScrollTo(int x, int y)
        {
            Logger.GetInstance().LogLine($"Scrolling window to ({x}, {y})...");
            string code = $"window.scroll({x}, {y});";
            IJavaScriptExecutor executor = (IJavaScriptExecutor)instance;
            executor.ExecuteScript(code);
        }

        public static void Zoom(int value)
        {
            Logger.GetInstance().LogLine($"Zooming window to {value}%...");
            string code = $"document.body.style.zoom='{value}%'";
            IJavaScriptExecutor executor = (IJavaScriptExecutor)instance;
            executor.ExecuteScript(code);
        }

        public static void Close()
        {
            Logger.GetInstance().LogLine($"Closing instance...");
            GetInstance().Close();
        }

        public static void Quit()
        {
            Logger.GetInstance().LogLine($"Quiting instance...");
            GetInstance().Quit();
        }
    }
}