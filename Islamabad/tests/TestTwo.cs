using Islamabad.pageObjects;
using Islamabad.utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
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
    public class TestTwo : Base
    {
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
            js.ExecuteScript("document.querySelector('#fashion > div.fashion-header > div.right-items > customer-widget').shadowRoot.querySelector('div.customer-menu.active > div.menu-items > a:nth-child(1) > img').click();");

            homePage2.dBField().Click();
            // Use the VerticalCombineDecorator to capture entire page:
        }
    }
}
