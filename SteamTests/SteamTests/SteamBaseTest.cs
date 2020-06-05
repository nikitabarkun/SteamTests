using TestFramework;

namespace SteamTests
{
    public class SteamBaseTest
    {
        protected TestConfiguration Configuration;

        public void Setup()
        {
            SingleWebDriver.GetInstance();
            Configuration = SingleWebDriver.Configuration;
        }

        public void TearDown()
        {
            SingleWebDriver.Quit();
            Logger.GetInstance().CreateLog(Configuration.OutputPath);
        }
    }
}
