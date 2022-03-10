using Autofac;
using OpenQA.Selenium;
using PichonProject.Common;
using PichonProject.Interfaces;
using PichonProject.Paginas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PichonProject.Configuration
{
    public static class RegistrationBuilder
    {
        public static ContainerBuilder Register(this ContainerBuilder container, IWebDriver driver)
        {

            #region handlers
            container.RegisterType<SeleniumUtils>().As<ISeleniumUtils>().WithParameter("driver", driver);
            container.RegisterType<SeleniumUtils>().As<IControlLocator>().WithParameter("driver", driver);

            #endregion

            container.RegisterType<LoginPage>().As<ILoginPage>();
            container.RegisterType<HomePage>().As<IHomePage>();


            return container;
        }
    }
}
