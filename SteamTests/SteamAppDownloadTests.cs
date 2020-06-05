using NUnit.Framework;
using SteamTests.Pages;
using System;
using System.IO;
using TestFramework;

namespace SteamTests
{
    [TestFixture]
    public class SteamAppDownloadTests : SteamBaseTest
    {
        [SetUp]
        public new void Setup()
        {
            base.Setup();
        }

        [Test]
        public void SteamAppDownloadTest_FileDownloaded()
        {
            Logger.GetInstance().LogLine($"STEP: Opening main page...");
            MainPage mainPage = new MainPage();

            mainPage.DownloadButton.Click();
            Logger.GetInstance().LogLine($"STEP: Clicked download button on main page.");

            DownloadPage downloadPage = new DownloadPage();
            downloadPage.DownloadButton.Click();
            Logger.GetInstance().LogLine($"STEP: Clicked download button on download page.");

            string path = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            path = Path.Combine(path, "Downloads");
            bool isFileDownloaded = FileUtils.IsFileDownloaded(path, "SteamSetup*.exe");
            Assert.IsTrue(isFileDownloaded, $"File not found in {path}.");
            Logger.GetInstance().LogLine($"STEP: Test complete.");
        }

        [OneTimeTearDown]
        public new void TearDown()
        {
            base.TearDown();
        }
    }
}