using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Islamabad.pageObjects
{
    public class ProfilePage
    {
        private IWebDriver driver;
        private IJavaScriptExecutor js;
        public ProfilePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            this.js = (IJavaScriptExecutor)driver;

            //this refers to current class objects

        }


        [FindsBy(How = How.XPath, Using = "//input[@class='input au-target flatpickr-input active']")]
        private IWebElement dateBirth;

        [FindsBy(How = How.XPath, Using = "//*[@id='interstitial-main']/div[3]/div[1]/button")]
        private IWebElement logIn;

        [FindsBy(How = How.XPath, Using = "//input[@id='interstitial-login-email-input']")]
        private IWebElement emailID;

        [FindsBy(How = How.XPath, Using = "//input[@id='interstitial-login-password-input']")]
        private IWebElement passWord1;

        [FindsBy(How = How.XPath, Using = "//button[@id='interstitial-login-button']")]
        private IWebElement loginBtn;

       
        public IWebElement dBField()
        {
            return dateBirth;
        }
        public IWebElement goToLogin()
        {
            return logIn;
        }

        public IWebElement GetUser()
        {
            return (IWebElement)js.ExecuteScript("return document.querySelector('#fashion > div.fashion-header > div.right-items > customer-widget').shadowRoot.querySelector('div.customer-widget');");

        }

        //public IWebElement GetUserEmail()
        //{

        //return (IWebElement)js.ExecuteScript("return document.querySelector('#fashion > div.fashion-header > div.right-items > customer-widget').shadowRoot.querySelector('div.customer-menu.no-login.active .email-input input[type=email]');");  

        //}

        //public IWebElement GetUserPass()
        //{
        //    return (IWebElement)js.ExecuteScript("return document.querySelector('#fashion > div.fashion-header > div.right-items > customer-widget').shadowRoot.querySelector('div.customer-menu.no-login.active .password-input input[type=password]');");

        //}
        public void validLogin(String email, String pass)
        {
            emailID.SendKeys(email);          // Concept of Encapsulation 
            passWord1.SendKeys(pass);
            loginBtn.Click();
        }

    }
}

