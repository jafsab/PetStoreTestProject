using NUnit.Framework;
using OpenQA.Selenium;

namespace SpecFlowProject1.POM
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement UsernameField => _driver.FindElement(By.Id("user-name"));
        private IWebElement PasswordField => _driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => _driver.FindElement(By.Id("login-button"));
        private IWebElement ErrorMessage => _driver.FindElement(By.CssSelector(".error-message-container"));
        public void Login(string username, string password)
        {
            UsernameField.SendKeys(username);
            PasswordField.SendKeys(password);
            LoginButton.Click();
        }

        // Assertions
        public void AssertErrorMessageDisplayed()
        {
            Assert.IsTrue(ErrorMessage.Displayed, "Error message is displayed.");
            Thread.Sleep(1000);
        }

        public void AssertOpenInventoryPage()
        {
            Assert.AreEqual(_driver.Url, "https://www.saucedemo.com/inventory.html", "Inventory page is oppend");
            Thread.Sleep(1000);
        }
    }
}
