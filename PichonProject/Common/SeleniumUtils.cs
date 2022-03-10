using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PichonProject.Driver;
using PichonProject.Interfaces;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PichonProject.Common
{
    public class SeleniumUtils : ISeleniumUtils, IControlLocator
    {
        private readonly IWebDriver _driver;
        WebDriverWait wait;

        public SeleniumUtils(IWebDriver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
        }

        public void NavigateToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
            Thread.Sleep(1000);
            DriverActions.TakeTestScreenShot(_driver, "NavigateToUrl");
        }

        public String GetText(String str)
        {
            IWebElement element = wait.Until(driver => driver.FindElement(By.XPath(str)));
            return element.Text;
        }

        public String GetText(By element)
        {
            var div = wait.Until(ExpectedConditions.ElementIsVisible(element));
            //IWebElement web_element = wait.Until(driver => driver.FindElement(element));
            return div.Text;
        }

        public void SetText(By element, String text)
        {
            IWebElement web_element = wait.Until(driver => driver.FindElement(element));
            web_element.SendKeys(text);

            Thread.Sleep(1000);
            DriverActions.TakeTestScreenShot(_driver, "SetText");
        }

        public void Click(By element)
        {
            IWebElement web_element = wait.Until(driver => driver.FindElement(element));
            web_element.Click();
            Thread.Sleep(1000);
            DriverActions.TakeTestScreenShot(_driver, "Click");

        }

        public void Click(IWebElement element)
        {
            IWebElement web_element = wait.Until(driver => element);
            web_element.Click();

            Thread.Sleep(1000);
            DriverActions.TakeTestScreenShot(_driver, "Click");
        }

        public void enterValue(By element)
        {
            _driver.FindElement(element).SendKeys(Keys.Enter);
        }

        public IWebElement finElement(By locator)
        {
            IWebElement web_element = wait.Until(driver => driver.FindElement(locator));
            return web_element;
        }

        public IList<IWebElement> findElements(By locator)
        {
            IList<IWebElement> web_elements = wait.Until(driver => driver.FindElements(locator));
            return web_elements;
        }

        public IWebDriver GetDriver()
        {
            return _driver;
        }

    }
}
