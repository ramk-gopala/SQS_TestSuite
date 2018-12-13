using SQS.TestSuite.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using OpenQA.Selenium;

namespace SQS.TestSuite.Pages
{
    class HomePage
    {

        private readonly string _url = string.Empty;

        public HomePage(string url)
        {
            _url = url;
        }

        public void GotoHomePage()
        {
            DriverHelper.NavigateTo(_url);
        }

        public bool IsAtHomepage()
        {
            return DriverHelper.CurrentUrl == _url;
        }

        public bool IsLoggedIn()
        {
            //we will see "Settings" menu Link only when user Logged In
            var settingsNavLink = DriverHelper.Driver.FindElement(By.CssSelector("ul.nav.navbar-nav.pull-xs-right:nth-child(3) li.nav-item:nth-child(3) > a.nav-link"));
            return (settingsNavLink.Text.Trim() == "Settings");

        }

        public void gotoSignUp()
        {
            DriverHelper.Driver.FindElement(By.XPath("//a[contains(text(),'Sign up')]")).Click();
        }

        public string GetUserName()
        {
            return DriverHelper.Driver.FindElement(By.CssSelector("li.nav-item:nth-child(4) > a.nav-link.ng-binding")).Text.Trim();
        }

        public void gotoLogin()
        {
            DriverHelper.Driver.FindElement(By.XPath("//a[contains(text(),'Sign in')]")).Click();
        }

    }
}
