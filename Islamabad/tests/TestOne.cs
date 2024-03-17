using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using Shopist.pageObjects;
using Shopist.utilities;
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

namespace Shopist.tests
{
    public class TestOne : Base
    {

        [Test, Category("Smoke")]                                               //[Test, TestCaseSource("AddTestDataConfig"), Category("Regression")]

        public void ProfileUpdate()
        {
            ProfilePage profilePage = new ProfilePage(getDriver());
            profilePage.updateProfile("Prenzlauer Promenade 182", "Second Floor, Left side", "Berlin", "AL", "13189");
            Thread.Sleep(1000);
            Assert.That(profilePage.IsSuccessMessageDisplayed("Profile successfully saved. View updated profile"), Is.True);

        }
    }
}
