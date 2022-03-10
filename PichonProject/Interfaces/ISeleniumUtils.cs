using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PichonProject.Interfaces
{
    public interface ISeleniumUtils
    {
        public String GetText(String str);

        public String GetText(By element);

        public void SetText(By element, String text);

        public void Click(By element);

        public void Click(IWebElement element);

        public void enterValue(By element);

        public IWebElement finElement(By locator);

        public IList<IWebElement> findElements(By locator);

        public IWebDriver GetDriver();
    }
}
