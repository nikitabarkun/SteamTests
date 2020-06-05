using System.IO;
using Newtonsoft.Json;

namespace TestFramework
{
    public class TestConfiguration
    {
        public readonly string SiteName;
        public readonly string BrowserName;
        public readonly string OutputPath;
        public readonly string Language;
        public readonly string LocalizationPath;

        public TestConfiguration(string configPath)
        {
            ConfigurationSetting settings = JsonConvert.DeserializeObject<ConfigurationSetting>(File.ReadAllText(configPath));

            SiteName = settings.SiteName;
            BrowserName = settings.BrowserName;
            OutputPath = settings.OutputPath;
            Language = settings.Language;
            LocalizationPath = settings.LocalizationPath;
        }

        private class ConfigurationSetting
        {
            public string SiteName { get; set; }
            public string BrowserName { get; set; }
            public string OutputPath { get; set; }
            public string Language { get; set; }
            public string LocalizationPath { get; set; }
        }
    }
}