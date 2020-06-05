using System;
using System.IO;

namespace TestFramework
{
    public class Logger
    {
        private static Logger instance;

        private static string text;

        public static Logger GetInstance()
        {
            if (instance == null)
            {
                instance = new Logger();
            }
            return instance;
        }

        private Logger()
        {
            text = "";
        }

        public void LogLine(string line)
        {
            DateTime current = DateTime.Now;
            text = $"{text}\n[{current}]{line}";
        }

        public void CreateLog(string path)
        {
            DateTime current = DateTime.Now;
            File.WriteAllText($"{path}/{current.Ticks}-LOG.txt", text);
        }
    }
}
