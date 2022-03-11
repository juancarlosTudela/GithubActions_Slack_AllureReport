using OpenQA.Selenium;
using PichonProject.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PichonProject.Resources;
using PichonProject.Paginas;
using PichonProject.Paginas.Base;
using Autofac;
using PichonProject.Interfaces;
using PichonProject.Configuration;
using NUnit.Allure.Core;
using Allure.Commons;
using NUnit.Framework.Interfaces;

namespace PichonProject.Test
{
    [TestFixture]
    [AllureNUnit]
    public class WebTest
    {
        public IWebDriver? driver;
        DriverFactory? driverFactory;
        protected IPageFactory? Page;
        string? hubUrl;
        //protected SearchPage? search;
        //protected PurchasePage? purchase;

        [SetUp]
        public void Setup()
        {
            driverFactory = new DriverFactory();
            //driverFactory.getDriverBrowser(config_properties.browser);
            //driver = driverFactory.getDriver();
            AllureLifecycle.Instance.CleanupResultDirectory();
            hubUrl = "http://localhost:4444/wd/hub";
            driver = driverFactory.CreateInstance(Enum.BrowserType.Chrome, hubUrl);
            driver.Manage().Window.Maximize();

            var container = new ContainerBuilder().Register(driver);
            Page = new PichonPageFactory(container.Build());
        }


        [TearDown]
        public void TearDown()
        {
           //driverFactory.tearDown();
           DriverActions.TakeTestScreenShot(driver);
           driver.Close();
        }

        
    }
}
