using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SQS.TestSuite.Common
{
    class DriverHelper
    {
        private static IWebDriver _driver;

        public DriverHelper(BrowserType browserType)
        {
        }

        public static void InitializeWebDriver(BrowserType browserType)
        {
            switch (browserType)
            {
                default:
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    _driver = new ChromeDriver();
                    break;
                case BrowserType.Firefox:
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    _driver = new FirefoxDriver();
                    break;
                case BrowserType.IE:
                    new DriverManager().SetUpDriver(new InternetExplorerConfig());
                    _driver = new InternetExplorerDriver();
                    break;
            }
        }

        public static IWebDriver Driver
        {
            get
            {
                return _driver;
            }
        }


        public static string CurrentUrl
        {
            get
            { return _driver.Url; }
        }

        public static void MaximizeBrowser()
        {
            _driver.Manage().Window.Maximize();
        }

        public static void CloseBrowser()
        {
            _driver.Close();
        }

        public static void NavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public static void ApplyImplicitWaits(double waitSeconds)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(waitSeconds);
        }

        public static void TakeScreenshot(string fileName)
        {
            ((ITakesScreenshot)_driver).GetScreenshot().SaveAsFile(fileName, ScreenshotImageFormat.Png);
        }
    }

    public enum BrowserType
    {
        Chrome,
        Firefox,
        IE,
        Opera
    }


}
