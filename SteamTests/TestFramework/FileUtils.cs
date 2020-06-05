using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace TestFramework
{
    public class FileUtils
    {
        public static bool IsFileDownloaded(string path, string fileName)
        {
            int triesToFindFile = 100000;
            for (int i = 0; i < triesToFindFile; i++)
            {
                if (IsFileExists(path, fileName))
                {
                    Logger.GetInstance().LogLine($"File {path}{fileName} found.");
                    return true;
                }
            }
            Logger.GetInstance().LogLine($"File {path}{fileName} not found.");
            return false;
        }

        public static bool IsFileExists(string path, string fileName)
        {
            return Directory.EnumerateFileSystemEntries(path, $"{fileName}").Any();
        }

        public static string GetLocalizedString(string key)
        {
            string localization = SingleWebDriver.Configuration.Language;
            string path = SingleWebDriver.Configuration.LocalizationPath;
            var doc = XDocument.Load($"{path}{localization}.xml");
            return doc.Descendants("key")
                       .Where(c => ((string)c.Attribute("name")).Equals(key))
                       .Select(c => (string)c.Element("value"))
                       .FirstOrDefault()
                       .Trim();
        }

        public static void WriteXml(string path, string name, object obj)
        {
            XmlSerializer formatter = new XmlSerializer(obj.GetType());

            using (FileStream fs = new FileStream($"{path}{name}", FileMode.Create))
            {
                formatter.Serialize(fs, obj);
            }
            Logger.GetInstance().LogLine($"Wrote {path}{name} file.");
        }

        public static T ReadXml<T>(string path)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                Logger.GetInstance().LogLine($"Raeding {path} file...");
                return (T)formatter.Deserialize(fs);
            }
        }
    }
}
