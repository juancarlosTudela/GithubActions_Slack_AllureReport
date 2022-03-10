using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PichonProject.Test.PageTest
{
    
    public class LoginTest : WebTest
    {
        /*[Test]
        [Category("SampleTag")]
        [Description("Test1")]
        [AllureTag("NUnit", "Debug")]
        [AllureSeverity(SeverityLevel.critical)]
        //[AllureFeature("Core")]
        public void ErrorMessage()
        {
            Console.WriteLine("TEST 01 IN PROCESS");
            Page.LoginPage().goLoginPage().insertDataLogin_Error().validarTxtErrorUser();
        }*/

        [Test]
        [Category("SampleTag")]
        [Description("Test1")]
        [AllureTag("NUnit", "Debug")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Core")]
        public void ValidateLogin()
        {
            Console.WriteLine("TEST 02 IN PROCESS");
            Page.LoginPage().goLoginPage().insertDataLogin_Successful().validateSuccessfulLogin();
        }
    }
}
