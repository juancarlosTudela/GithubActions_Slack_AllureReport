using NUnit.Framework;
using OpenQA.Selenium;
using PichonProject.Interfaces;
using PichonProject.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Allure.Core;
using Allure.Commons;
using System.Threading;

namespace PichonProject.Paginas
{
    public class LoginPage : WebPage, ILoginPage
    {
        public LoginPage(ISeleniumUtils seleniumUtils, IControlLocator controlLocator) : base(seleniumUtils, controlLocator)
        //public LoginPage(IWebDriver driver) : base(driver)
        {
        }



        public string Brand => "generic";

        /*String*/
        string textError_Xpath = "//div[@class='alert alert-danger failed']";
        //string Dashborad = "";

        string dataUser = "user@phptravels.com";
        string dataPassError = "demousert";

        string dataPass = "demouser";

        string username_Xpath = "//input[@name='email']";
        string password_Xpath = "//input[@name='password']";


        /*Web Elements*/
        By btnLogin = By.XPath("//button[@class='btn btn-default btn-lg btn-block effect ladda-button waves-effect']");
        By Dashborad = By.XPath("//h2[contains(text(),'Hi,')]");

        /*Methods*/
        public LoginPage insertDataLogin_Error()
        {
            _seleniumUtils.SetText(By.XPath(username_Xpath), dataUser);
            _seleniumUtils.SetText(By.XPath(password_Xpath), dataPassError);
            _seleniumUtils.Click(btnLogin);
            return new LoginPage(_seleniumUtils, _controlLocator);
        }

        public LoginPage insertDataLogin_Successful()
        {
            _seleniumUtils.SetText(By.XPath(username_Xpath), dataUser);
            _seleniumUtils.SetText(By.XPath(password_Xpath), dataPass);
            _seleniumUtils.Click(btnLogin);
            return new LoginPage(_seleniumUtils, _controlLocator);
        }

        public void clickButtonLogin()
        {
            _seleniumUtils.Click(btnLogin);
        }


        public LoginPage goLoginPage()
        {
            //driver.Navigate().GoToUrl(config_properties.url);
            _controlLocator.NavigateToUrl(config_properties.url);
            return new LoginPage(_seleniumUtils, _controlLocator);
        }

        public void validarTxtErrorUser()
        {
            var textError = _seleniumUtils.GetText(By.XPath(textError_Xpath));
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                Assert.AreEqual("Wrong credentials. try again!", textError);
            }, "validate error");

            Console.WriteLine("TEST1: PASSED");

        }

        public void validateSuccessfulLogin()
        {
            Thread.Sleep(5000);
            var textConfirmLogin = _seleniumUtils.GetText(Dashborad);

            AllureLifecycle.Instance.WrapInStep(() =>
            {
                Assert.AreEqual("Hi, Demo Welcome Back", textConfirmLogin);
            }, "successful login");


        }
    }
}
