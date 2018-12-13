using NUnit.Framework;
using SQS.TestSuite.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SQS.TestSuite
{
    [Binding]
    public sealed class Hooks
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            string url = TestContext.Parameters.Get("url", "https://angularjs.realworld.io/");
            ScenarioContext.Current.Add("url", url);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            DriverHelper.Driver.Manage().Cookies.DeleteAllCookies();
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            //e.g. nunit3-console.exe --params:browser=Firefox \SQS.TestSuite.dll
            //If nothing specified, test will run in Chrome browser
            //string browser = TestContext.Parameters.Get("browser", "Chrome");
            //var browserType = (BrowserType)Enum.Parse(typeof(BrowserType), browser);
            DriverHelper.InitializeWebDriver(BrowserType.Chrome);

        }

        [AfterFeature]
        public static void AfterFeature()
        {
            DriverHelper.Driver.Quit();

        }

    }
}
