using OpenQA.Selenium;
using System;

namespace TestFramework.Elements
{
    public class TextBox : BaseElement
    {
        public TextBox(By locator, string name) : base(locator, name)
        {

        }

        public void SendKeys(string text)
        {
            if (IsEnabled())
            {
                driver.FindElement(locator).SendKeys(text);
                Logger.GetInstance().LogLine($"Sent '{text}' keys to {Name} text box.");
                return;
            }
            Logger.GetInstance().LogLine($"ERROR: Can't find text box {Name} to send keys.");
            throw new Exception($"Can't find text box {Name} to send keys.");
        }
    }
}
