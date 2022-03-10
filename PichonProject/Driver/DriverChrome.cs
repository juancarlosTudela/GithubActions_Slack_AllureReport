using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PichonProject.Driver
{
    internal class DriverChrome : Driver
    {
        public override void destroyDriver()
        {
            driver.Close();
        }

        public override void initDriver()
        {
            driver = new ChromeDriver();
        }

        public override IWebDriver returnDriver()
        {
            return driver;
        }
    }
}
