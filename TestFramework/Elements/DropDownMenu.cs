using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace TestFramework.Elements
{
    public class DropDownMenu : BaseElement
    {
        private List<IWebElement> elements = new List<IWebElement>();

        /// <summary>
        /// Creates drop-down menu and adds elements using elementsSelector parameter.
        /// </summary>
        /// <param name="elementsLocator">Locator of drop-down menu elements, which will be added automatically by this locator.</param>
        /// <param name="selector">Selector of drop-down menu.</param>
        /// <param name="name">Name of drop-down menu.</param>
        public DropDownMenu(By elementsLocator, By locator, string name) : base(locator, name)
        {
            foreach (var element in driver.FindElements(elementsLocator))
            {
                elements.Add(element);
                Logger.GetInstance().LogLine($"Added element to {Name} drop-down menu.");
            }
            Logger.GetInstance().LogLine($"Created {Name} drop-down menu.");
        }
        
        private IWebElement GetElementByInnerText(string text)
        {
            IWebElement element = elements.Find(x => x.GetAttribute("innerText") == text);
            if (element != null)
            {
                return element;
            }
            Logger.GetInstance().LogLine($"ERROR: Can't find element {Name} to get Text attribute.");
            throw new Exception($"Can't find element {Name} to get Text attribute.");
        }

        public void ClickElementByInnerText(string text)
        {
            GetElementByInnerText(text).Click();
        }
    }
}
