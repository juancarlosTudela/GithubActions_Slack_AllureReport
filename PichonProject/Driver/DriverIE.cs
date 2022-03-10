using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PichonProject.Driver
{
    internal class DriverIE : Driver
    {
        public override void destroyDriver()
        {
            driver.Close();
        }

        public override void initDriver()
        {
            driver = new InternetExplorerDriver();
        }

        public override IWebDriver returnDriver()
        {
            return driver;
        }
    }
}
