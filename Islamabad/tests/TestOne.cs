using Islamabad.pageObjects;
using Islamabad.utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDSE;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;

namespace Islamabad.tests
{
    public class E2ETest : Base
    {

        [Test, Category("Regression")]
        //[Test, TestCaseSource("AddTestDataConfig"), Category("Regression")]
        public void FirstTimeUserFlow()
        {
            HomePage homePage = new HomePage(getDriver());
            homePage.basicHomePage();
            homePage.validRegistration("Test@g.caqwe", "123456789", "123456789", "testcaase0000oo ", "QQQqQA");
            homePage.checkTerms();
            homePage.registeredButton().Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1000));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='interstitial-completion-step']/div[2]")));

            homePage.crossBtn().Click();

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            // Execute JavaScript code to find and interact with an element inside the Shadow DOM
            js.ExecuteScript("document.querySelector('#fashion > div.fashion-header > div.right-items > customer-widget').shadowRoot.querySelector('div.customer-widget').click();");

            js.ExecuteScript("document.querySelector('#fashion > div.fashion-header > div.right-items > customer-widget').shadowRoot.querySelector('div.customer-menu.active > div.menu-items > a:nth-child(1) > span').click();");

            homePage.dBField().Click();
        }

        [Test, Category("Smoke")]
        public void RegisteredUserLogInFlow()
        {
            HomePage homePage2 = new HomePage(getDriver());

            homePage2.okButton().Click();
            homePage2.typeSel().Click();

            ProfilePage profilePage = new ProfilePage(getDriver());

            profilePage.goToLogin().Click();
            profilePage.validLogin("sarmed.mujaddid@gmail.com", "123456789");

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            js.ExecuteScript("document.querySelector('#fashion > div.fashion-header > div.right-items > customer-widget').shadowRoot.querySelector('div.customer-widget').click();");
            Thread.Sleep(1000);
            js.ExecuteScript("document.querySelector('#fashion > div.fashion-header > div.right-items > customer-widget').shadowRoot.querySelector('div.customer-menu.active > div.menu-items > a:nth-child(1) > span').click();");

            homePage2.dBField().Click();
        }
    }
}
