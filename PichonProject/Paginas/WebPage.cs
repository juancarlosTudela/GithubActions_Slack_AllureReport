using OpenQA.Selenium;
using PichonProject.Common;
using PichonProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PichonProject.Paginas
{
    public class WebPage
    {
        //protected IWebDriver driver;
        //public SeleniumUtils seleniumUtils;
        protected ISeleniumUtils _seleniumUtils;
        protected IControlLocator _controlLocator;


        public WebPage(ISeleniumUtils seleniumUtils, IControlLocator controlLocator)
        {
            //this.driver = driver;
            //seleniumUtils = new SeleniumUtils(driver);
            _seleniumUtils = seleniumUtils;
            _controlLocator = controlLocator;
        }
    }
}
