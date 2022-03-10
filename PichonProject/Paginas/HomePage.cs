using Allure.Commons;
using NUnit.Framework;
using OpenQA.Selenium;
using PichonProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Allure.Core;
using Allure.Commons;

namespace PichonProject.Paginas
{
    public class HomePage : WebPage, IHomePage
    {
        public HomePage(ISeleniumUtils seleniumUtils, IControlLocator controlLocator) : base(seleniumUtils, controlLocator)
        {

        }

        //String
        string equipment = "Equipment";
        string modelEquipment = "SIMATIC S7-1500";

        //Web Elements
        By btnLogin = By.XPath("//button[@class='uk-button uk-button-primary']");

        By btnMaterials = By.XPath("//*[@id='materials']/i");
        By txvMaterials = By.XPath("//div[contains(text(),'Materials')]");
        By btnMenu = By.XPath("//button[@id='secondary-nav-dropdown']");
        By btnEquipmentOption = By.XPath("//*[@id='navbar']/div[2]/div/a[4]");

        By btnAddNew = By.XPath("//button[@id='create-dropdown']");
        By btnAddIEquipmet = By.XPath("//a[contains(text(),'Individual')]");

        By selectTypeE = By.XPath("//*[@id='better_content']/div/div[2]/div/div/div[1]/div/div/div/table[1]/tbody/tr[1]/td[2]/div/div[1]/input");
        By optionTypeE = By.XPath("//a[contains(text(),'Controller')][1]");
        By selectManufacE = By.XPath("//*[@id='better_content']/div/div[2]/div/div/div[1]/div/div/div/table[1]/tbody/tr[2]/td[2]/div/div[1]/input");
        By optionManufacE = By.XPath("//a[contains(text(),'Siemens')]");
        // spanModelE = By.XPath("//span[contains(text(),'Type here')]");
        By spanModelE = By.XPath("//*[@id='better_content']/div/div[2]/div/div/div[1]/div/div/div/table[1]/tbody/tr[3]/td[2]/div/div[1]/span/span");

        By spanModelUpdate = By.XPath("//span[contains(text(),'SIMATIC S7-1500')]");

        By inputTextModelE = By.XPath("//*[@id='better_content']/div/div[2]/div/div/div[1]/div/div/div/table[1]/tbody/tr[3]/td[2]/div/div[1]/span/input");
        By inputTextModelU = By.XPath("//*[@id='better_content']/div/div[3]/div/div/div/div/div/div/table/tbody/tr[3]/td[2]/div/div[1]/span/input");
        By btnRegisterNewEquipment = By.XPath("//button[contains(text(),'Register')]");
        By txvResultRegister = By.XPath("//*[@id='better_content']/div/div[1]/div[1]/div[1]");

        By txvAddedEquipment = By.XPath("//div[@class='settings-view-header__title']");

        By btnConfiguration = By.XPath("//button[@id='actions-dropdown']");
        By btnEditEquipment = By.XPath("//*[@id='better_content']/div/div[1]/div/div[2]/div/div/a[1]");
        By btnSave = By.XPath("//*[@id='better_content']/div/div[3]/div/div/div/div/div/div/div/div[1]/div/div/button[2]");
        By btnBackPage = By.XPath("//a[@id='back-to-asset']");

        By settings = By.XPath("//*[@id='actions-dropdown']");
        By btnDelete = By.XPath("//*[@id='better_content']/div/div[1]/div/div[2]/div/div/a[3]");
        By btnConfirmDelete = By.XPath("//button[@class='btn btn-danger']");

        By btnProfileDropDown = By.XPath("//button[@id='profile-dropdown']");
        By btnLogOut = By.XPath("//*[@id='logout']");

        public string Brand => throw new NotImplementedException();

        public HomePage addNewEquipment()
        {
            _seleniumUtils.Click(btnAddNew);
            _seleniumUtils.Click(btnAddIEquipmet);
            _seleniumUtils.Click(selectTypeE);
            Thread.Sleep(1000);
            _seleniumUtils.Click(optionTypeE);
            _seleniumUtils.Click(selectManufacE);
            Thread.Sleep(2000);
            _seleniumUtils.Click(optionManufacE);
            _seleniumUtils.Click(spanModelE);
            Thread.Sleep(1000);
            _seleniumUtils.SetText(inputTextModelE, modelEquipment);
            _seleniumUtils.enterValue(inputTextModelE);
            Thread.Sleep(1000);
            _seleniumUtils.Click(btnRegisterNewEquipment);

            return new HomePage(_seleniumUtils, _controlLocator);
        }

        public void deleteDataEquitment()
        {
            Thread.Sleep(2000);
            IList<IWebElement> tags = _seleniumUtils.findElements(By.TagName("bdi"));

            if (tags.Count > 0)
            {
                for (int i = 0; i < tags.Count; i++)
                {
                    tags = _seleniumUtils.findElements(By.TagName("bdi"));
                    IWebElement tag = tags[0];
                    _seleniumUtils.Click(tag);
                    Thread.Sleep(2000);
                    _seleniumUtils.Click(settings);
                    _seleniumUtils.Click(btnDelete);
                    Thread.Sleep(2000);
                    _seleniumUtils.Click(btnConfirmDelete);
                    Thread.Sleep(2000);
                }
            }
        }

        public HomePage editDataEquipment()
        {
            Thread.Sleep(2000);
            IList<IWebElement> tags = _seleniumUtils.findElements(By.TagName("bdi"));
            int v = 16;
            if (tags.Count > 0)
            {
                for (int i = 0; i < tags.Count; i++)
                {
                    tags = _seleniumUtils.findElements(By.TagName("bdi"));
                    _seleniumUtils.Click(tags[i]);
                    Thread.Sleep(1000);
                    _seleniumUtils.Click(btnConfiguration);
                    _seleniumUtils.Click(btnEditEquipment);
                    _seleniumUtils.Click(spanModelUpdate);
                    _seleniumUtils.SetText(inputTextModelU, modelEquipment + "v" + v.ToString());
                    _seleniumUtils.enterValue(inputTextModelU);
                    _seleniumUtils.Click(btnSave);
                    _seleniumUtils.Click(btnMaterials);
                    v++;
                    Thread.Sleep(1000);
                    Console.WriteLine("EQUIPMENT " + i + " UPDATE ");
                }
            }

            return new HomePage(_seleniumUtils, _controlLocator);
        }

        public HomePage goAnyPage(string material)
        {
            try
            {
                _seleniumUtils.Click(btnMaterials);

                string xpath = "//*[@id='navbar']/div[2]/div/a[contains(text(),'" + material + "')]";
                if (!material.Equals("Antibodies"))
                {
                    _seleniumUtils.Click(btnMenu);
                    _seleniumUtils.Click(By.XPath(xpath));
                }
            }
            catch (Exception ex)
            {
                //string _testName = GetTestName(_output);
                //
                Console.WriteLine(ex.Message);
                LogOut();

            }


            return new HomePage(_seleniumUtils, _controlLocator);
        }

        public HomePage goEquipmentPage()
        {
            _seleniumUtils.Click(btnMaterials);
            _seleniumUtils.Click(btnMenu);
            _seleniumUtils.Click(btnEquipmentOption);
            return new HomePage(_seleniumUtils, _controlLocator);
        }

        public void LogOut()
        {
            _seleniumUtils.Click(btnProfileDropDown);
            _seleniumUtils.Click(btnLogOut);
            string signin = _seleniumUtils.GetText(btnLogin);
            Thread.Sleep(3000);
            Assert.AreEqual("SIGN IN", signin);
            Console.WriteLine("Closed Session");
        }

        public void validateSuccessfulAddressing()
        {
            var textConfirm = _seleniumUtils.GetText(btnMenu);
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                Assert.AreEqual(equipment, textConfirm);
            }, "Go page");
                
            Console.WriteLine("TEST: SUCCESSFUL ADDRESSING TO EQUIPMENT PAGE");
        }

        public void validateSuccessfulInsertion()
        {
            Thread.Sleep(2000);
            var text = _seleniumUtils.GetText(txvAddedEquipment);
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                if (text.Contains("EQ-")) { Assert.True(true); }
                else { Assert.False(true); }
            },"Insert data");
            
            Console.WriteLine("TEST: SUCCESSFUL INSERTION OF EQUIPMENT");

        }

        public HomePage clickMaterialsIcon()
        {
            _seleniumUtils.Click(btnMaterials);
            return new HomePage(_seleniumUtils, _controlLocator);
        }

        public HomePage addNewMaterial()
        {
            _seleniumUtils.Click(btnAddNew);
            _seleniumUtils.Click(btnAddIEquipmet);
            return new HomePage(_seleniumUtils, _controlLocator);
        }
    }
}
