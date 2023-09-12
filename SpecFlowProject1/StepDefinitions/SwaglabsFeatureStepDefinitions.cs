using NUnit.Framework;
using OpenQA.Selenium;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class SwaglabsFeatureStepDefinitions
    {
        private IWebDriver _driver;

        public SwaglabsFeatureStepDefinitions(IWebDriver driver)
        {
            this._driver = driver;
        }

        [Given(@"open the browser")]
        public void GivenOpenTheBrowser()
        {
            // moved to hooks file
            //IWebDriver _driver = new ChromeDriver();
            //_driver.Manage().Window.Maximize();
        }

        [Given(@"enter the url")]
        public void GivenEnterTheUrl()
        {
            // moved to hooks file
            //_driver.Url = _url;
        }

        [Given(@"enter the user name")]
        public void GivenEnterTheUserName()
        {
            var UsernameField = _driver.FindElement(By.Id("user-name"));
            UsernameField.SendKeys("standard_user");
        }

        [Given(@"enter user password")]
        public void GivenEnterUserPassword()
        {
            var PasswordField = _driver.FindElement(By.Id("password"));
            PasswordField.SendKeys("secret_sauce");
        }

        [When(@"click login button")]
        public void WhenClickLoginButton()
        {
            var LoginButton = _driver.FindElement(By.Id("login-button"));
            LoginButton.Click();
        }

        [Then(@"login succeed and go to inventory page")]
        public void ThenLoginSucceedAndGoToInventory()
        {
            Assert.AreEqual(_driver.Url, "https://www.saucedemo.com/inventory.html");
            Thread.Sleep(1500);
        }
    }
}
