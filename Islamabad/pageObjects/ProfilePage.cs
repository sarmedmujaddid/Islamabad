using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopist.pageObjects
{
    public class ProfilePage
    {
        private IWebDriver driver;

        public ProfilePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            //this refers to current class objects
        }

        //Pageobject Factory

        //[FindsBy(How = How.XPath, Using = "//div[@class='menu-item-large'][normalize-space()='My Profile']")]
        [FindsBy(How = How.CssSelector, Using = "a[class='profile'] div[class='menu-item-large']")]
        private IWebElement profileBtn;

        [FindsBy(How = How.XPath, Using = "//a[@class='button']")]
        private IWebElement editBtn;

        [FindsBy(How = How.Id, Using = "address1")]
        private IWebElement addField;

        [FindsBy(How = How.Id, Using = "address2")]
        private IWebElement addTwo;

        [FindsBy(How = How.Id, Using = "addressCity")]
        private IWebElement cityField;

        [FindsBy(How = How.CssSelector, Using = "input[type='search']")]
        private IWebElement stateField;

        [FindsBy(How = How.Id, Using = "addressZipcode")]
        private IWebElement zipField;

        [FindsBy(How = How.XPath, Using = "//button[@class='button big inverted']")]
        private IWebElement saveBtn;

        [FindsBy(How = How.CssSelector, Using = ".success.banner")]
        private IWebElement successMge;

        // Methods

        public IWebElement profileButton()
        {
            return profileBtn;                // Concept of Encapsulation
        }

        public IWebElement editProfile()
        {
            return editBtn;              // Concept of Encapsulation
        }
        public IWebElement addressField()
        {
            return addField;           // Concept of Encapsulation 
        }

        public IWebElement addressTwo()
        {
            return addTwo;           // Concept of Encapsulation 
        }
        public IWebElement cityAddress()
        {
            return cityField;
        }

        public IWebElement stateAddress()
        {

            return stateField;
        }

        public void SelectStateAddress(string state)
        {
            stateAddress().Click();
            SelectElement selectElement = new SelectElement(stateAddress());
            selectElement.SelectByText(state);

        }

        public IWebElement zipAddress()
        {
            return zipField;
        }

        public IWebElement saveButton()
        {
            return saveBtn;
        }

        public IWebElement successMessage()
        {
            return successMge;
        }

        public void updateProfile(string address, string addresstwo, string city, string state, string zip)
        {
            Thread.Sleep(10);
            profileButton().Click();
            editProfile().Click();
            addressField().Click();
            addressField().Clear();
            addressField().SendKeys(address);
            addressTwo().Click();
            addressTwo().Clear();
            addressTwo().SendKeys(addresstwo);
            cityAddress().Click();
            cityAddress().Clear();
            cityAddress().SendKeys(city);
            stateAddress().Click();
            stateAddress().SendKeys(state);
            zipAddress().Click();
            zipAddress().Clear();
            zipAddress().SendKeys(zip);
            saveButton().Click();
            successMessage().Click();

        }

        public bool IsSuccessMessageDisplayed(string expectedMessage)
        {
            try
            {
                IWebElement successMessageElement = driver.FindElement(By.CssSelector(".success.banner"));

                if (successMessageElement != null)
                {
                    string actualMessage = successMessageElement.Text;
                    return actualMessage.Contains(expectedMessage);
                }
            }
            catch (NoSuchElementException)
            {
                return false;
            }

            return false;
        }
    }
}