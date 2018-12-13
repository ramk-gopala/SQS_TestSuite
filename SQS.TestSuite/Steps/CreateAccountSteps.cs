using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;
using SQS.TestSuite.Pages;
using SQS.TestSuite.Common;

namespace SQS.TestSuite.Steps
{
    [Binding]
    class CreateAccountSteps
    {

        string _baseURL;
        HomePage _homePage;
        SignupPage _signupPage;

        public CreateAccountSteps()

        {
            _baseURL = ScenarioContext.Current.Get<string>("baseURL");

            _homePage = new HomePage(_baseURL);
            _signupPage = new SignupPage();
        }


        [Given(@"I am on Home page")]
        public void GivenIAmOnHomePage()
        {
            _homePage.GotoHomePage();

            Assert.That(_homePage.IsAtHomepage(), Is.True, "Unable to load Home page");
        }

        [Given(@"I am not logged in")]
        public void GivenIAmNotLoggedIn()
        {
            Assert.That(_homePage.IsLoggedIn(), Is.False, "Already logged In. Cannot do Registration!");
        }

        [When(@"I click Sign Up")]
        public void WhenIClickSignUp()
        {
            _homePage.gotoSignUp();
        }


        [When(@"I complete the sign up form")]
        public void WhenICompleteTheSignUpForm(Table table)
        {
            dynamic accountInfo = table.CreateDynamicInstance();

            ScenarioContext.Current.Add("username", (string)accountInfo.UserName);

            _signupPage.RegisterAccount((string)accountInfo.UserName, (string)accountInfo.Email, (string)accountInfo.Password);
        }

        [Then(@"I am logged in")]
        public void ThenIAmLoggedIn()
        {
            Assert.That(_homePage.IsLoggedIn(), Is.True, "Unable to Login");
        }

        [Then(@"my username is displayed")]
        public void ThenMyUsernameIsDisplayed()
        {
            string userNameExpected = ScenarioContext.Current.Get<string>("username");

            Assert.That(_homePage.GetUserName(), Is.EqualTo(userNameExpected), "Given User Name does display on Home page");
        }

        [Then(@"I should be in Sign Up page")]
        public void ThenIShouldBeInSignUpPage()
        {
            Assert.That(_signupPage.IsAtPage(), Is.True, "Unable to load Sign Up page!");

        }

        [When(@"I enter already existing account details to Register account")]
        [When(@"I enter  account registration details with undersscore in username")]
        public void WhenIEnterAccountDetailsToRegisterAccount(Table table)
        {
            dynamic accountInfo = table.CreateDynamicInstance();

            _signupPage.RegisterAccount((string)accountInfo.UserName, (string)accountInfo.Email, (string)accountInfo.Password);
        }

    }
}
