using OpenQA.Selenium;
using SQS.TestSuite.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQS.TestSuite.Pages
{
    class SignupPage
    {

        IWebElement txtUserName, txtEmail, txtPassword, btnSignUp;

        string signUpPageURL = "https://angularjs.realworld.io/#/register";

        public SignupPage()
        {

            txtUserName = DriverHelper.Driver.FindElement(By.CssSelector("fieldset.form-group:nth-child(1) > input.form-control.form-control-lg.ng-pristine.ng-untouched.ng-valid.ng-empty"));

            txtEmail = DriverHelper.Driver.FindElement(By.CssSelector("fieldset.form-group:nth-child(2) > input.form-control.form-control-lg.ng-pristine.ng-untouched.ng-valid.ng-empty.ng-valid-email"));


            txtPassword = DriverHelper.Driver.FindElement(By.CssSelector("fieldset.form-group:nth-child(3) > input.form-control.form-control-lg.ng-pristine.ng-untouched.ng-valid.ng-empty"));

            btnSignUp = DriverHelper.Driver.FindElement(By.XPath("//button[@type='submit']"));
        }

        public string GetTitle()
        {
            return DriverHelper.Driver.FindElement(By.XPath("//h1[@class='text-xs-center ng-binding']")).Text;

        }

        public void RegisterAccount(string userName, string emailId, string password)
        {
            txtUserName.SendKeys(userName);
            txtEmail.SendKeys(emailId);
            txtPassword.SendKeys(password);
            btnSignUp.Submit();
            DriverHelper.ApplyImplicitWaits(1000);
        }

        public bool IsAtPage()
        {
            return (DriverHelper.Driver.Url == signUpPageURL);
        }
    }
}
