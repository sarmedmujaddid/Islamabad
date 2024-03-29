﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.Configuration;
using System.Reactive.Concurrency;
using WebDriverManager.DriverConfigs.Impl;

namespace Islamabad.utilities
{
    public class Base
    {
    
        public ExtentReports extent;
        public ExtentTest test;
        public IWebDriver driver;

        //report file

        [OneTimeSetUp]
        public void Setup()

        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportPath = projectDirectory + "//index.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Local host");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Username", "Sarmad Ali ");
        }

        [SetUp]
        public void StartBrowser()

        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

            //Configuration

            String browserName = ConfigurationManager.AppSettings["browser"];
            InitBrowser(browserName);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            driver.Manage().Window.Maximize();
            driver.Url = "https://www.newyorker.de";

            // Assuming driver is your WebDriver instance - Cookies Acceptance
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            // Execute JavaScript code to find and interact with an element inside the Shadow DOM
            js.ExecuteScript("document.querySelector('#fashion > cookie-banner').shadowRoot.querySelector('div > div.cookie-banner-controls > button:nth-child(1)').click();");
        }

        public IWebDriver getDriver()

        {
            return driver;
        }

        public void InitBrowser(string browserName)

        {
            switch (browserName)
            {
                case "Firefox":

                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;

                case "Chrome":

                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;

                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;
            }
        }

        [TearDown] 
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;

            DateTime time = DateTime.Now;
            String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";

            if (status == TestStatus.Failed)
            {

                test.Fail("Test is failing!", captureScreenShot(driver, fileName));
                test.Log(Status.Fail, "Test failed with logtrace" + stackTrace);

            }
            else if (status == TestStatus.Passed)
            {
                extent.Flush();
                driver.Quit();
            }
        }

        //public static JsonReader getDataParser()
        //{
        //    return new JsonReader();
        //}

        public MediaEntityModelProvider captureScreenShot(IWebDriver driver, String screenShotName)

        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();
        }

    }
}
