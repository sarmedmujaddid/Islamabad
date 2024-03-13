using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Islamabad.pageObjects
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            //this refers to current class objects
        }

        //Pageobject Factory

        [FindsBy(How = How.CssSelector, Using = "div[class='button-container toggleable'] button")]
        private IWebElement okayButn;

        [FindsBy(How = How.XPath, Using = "//div[normalize-space()='Damen']")]
        private IWebElement typeSelt;

        [FindsBy(How = How.CssSelector, Using = "button[onclick='handleClickRegisterFromMain()']")]
        private IWebElement registButn;

        [FindsBy(How = How.Id, Using = "interstitial-register-email-input")]
        private IWebElement emailID;

        [FindsBy(How = How.Id, Using = "interstitial-register-password-input")]
        private IWebElement passWord;

        [FindsBy(How = How.Id, Using = "interstitial-register-password-repeat-input")]
        private IWebElement repeatPass;

        [FindsBy(How = How.Id, Using = "interstitial-register-firstname-input")]
        private IWebElement fName;

        [FindsBy(How = How.Id, Using = "interstitial-register-lastname-input")]
        private IWebElement lName;

        [FindsBy(How = How.LinkText, Using = "AGB")]
        private IWebElement hyperLink;

        [FindsBy(How = How.Id, Using = "interstitial-register-button")]
        private IWebElement regButn;

        [FindsBy(How = How.CssSelector, Using = "div.customer-widget")]
        private IWebElement proBut;

        [FindsBy(How = How.XPath, Using = "//*[@id='x-close']")]
        private IWebElement crossButton;

        [FindsBy(How = How.XPath, Using = "//input[@au-target-id='1']")]
        private IWebElement dateBirth;

        // Methods

        public IWebElement okButton()
        {
            return okayButn;                // Concept of Encapsulation
        }

        public IWebElement typeSel()
        {
            return typeSelt;              // Concept of Encapsulation
        }
        public IWebElement registButton()
        {
            return registButn;           // Concept of Encapsulation 
        }

        public IWebElement crossBtn()
        {
            return crossButton;           // Concept of Encapsulation 
        }
        public IWebElement registeredButton()
        {
            return regButn;
        }

        public IWebElement proButton()
        {
            return proBut;
        }

        public IWebElement dBField()
        {
            return dateBirth;
        }

        public void basicHomePage()
        {
            okButton().Click();
            typeSel().Click();
            registButton().Click();
            //crossBtn().Click();
        }


        public void validRegistration(string email, string pass, string passrep, string fname, string lname)
        {
            emailID.SendKeys(email);          // Concept of Encapsulation 
            passWord.SendKeys(pass);
            repeatPass.SendKeys(passrep);
            fName.SendKeys(fname);
            lName.SendKeys(lname);
        }

        public void checkTerms()
        {
            string originalWindowHandle = driver.CurrentWindowHandle;
            hyperLink.Click();
            foreach (string windowHandle in driver.WindowHandles)
            {
                if (windowHandle != originalWindowHandle)
                {
                    driver.SwitchTo().Window(windowHandle);
                    break;
                }
            }
            driver.SwitchTo().Window(originalWindowHandle);
        }

    }
}
